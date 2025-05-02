// <copyright file="SkipList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList
{
    using System.Collections;

    /// <summary>
    /// An implementation of a skip list that supports the IListT interface.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public class SkipList<T> : IList<T>
    {
        private const int MaxLevel = 32;
        private const double Probability = 0.5;

        private readonly Random random = new Random();
        private readonly IComparer<T> comparer;
        private readonly Node head = new Node(default, MaxLevel);

        private int currentLevels = 1;
        private int count;
        private int version;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
        /// </summary>
        public SkipList()
        {
            this.comparer = Comparer<T>.Default;
            for (int i = 0; i < MaxLevel; ++i)
            {
                this.head.Width[i] = 1;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
        /// </summary>
        /// <param name="comparer">A comparator for comparing elements.</param>
        public SkipList(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            this.comparer = comparer;
            for (int i = 0; i < MaxLevel; ++i)
            {
                this.head.Width[i] = 1;
            }
        }

        /// <summary>
        /// Gets number of items in the list.
        /// </summary>
        public int Count => this.count;

        /// <summary>
        /// Gets a value indicating whether the list is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the element by the specified index.
        /// </summary>
        /// <param name="index">The element's index.</param>
        /// <returns>The element by index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">It is thrown if the index is out of range.</exception>
        /// <exception cref="InvalidDataException">It is thrown when the list structure is violated.</exception>
        /// <exception cref="NotImplementedException">It is thrown when trying to set a value.</exception>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                Node current = this.head;
                int currentIndex = -1;

                for (int i = this.currentLevels - 1; i >= 0; --i)
                {
                    while (current.Next[i] != null && currentIndex + current.Width[i] <= index)
                    {
                        currentIndex += current.Width[i];
                        current = current.Next[i];
                    }
                }

                for (int i = 0; i < index - currentIndex; ++i)
                {
                    if (current.Next[0] == null)
                    {
                        throw new InvalidDataException();
                    }

                    current = current.Next[0];
                }

                return current.Value;
            }

            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Adds an item to the end of the list.
        /// </summary>
        /// <param name="item">The element to add.</param>
        public void Add(T item) => this.Insert(this.count, item);

        /// <summary>
        /// Removes all items from the list.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < this.currentLevels; ++i)
            {
                this.head.Next[i] = null;
                this.head.Width[i] = 1;
            }

            this.count = 0;
            this.currentLevels = 1;
            this.version++;
        }

        /// <summary>
        /// Determines whether the list contains the specified element.
        /// </summary>
        /// <param name="item">The search element.</param>
        /// <returns>True if the element is found; otherwise, false.</returns>
        public bool Contains(T item) => this.FindNode(item) != null;

        /// <summary>
        /// Copies the list items to an array, starting from the specified index.
        /// </summary>
        /// <param name="array">The array to which the elements will be copied.</param>
        /// <param name="arrayIndex">The number of the position in the array to start copying from.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the provided array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">It is thrown If a negative starting position is specified.</exception>
        /// <exception cref="ArgumentException">It is thrown if there is not enough space in the array to copy.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < this.count)
            {
                throw new ArgumentException();
            }

            Node current = this.head.Next[0];
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next[0];
            }
        }

        /// <summary>
        /// Searching for the index of the first occurrence of the specified element.
        /// </summary>
        /// <param name="item">The desired element.</param>
        /// <returns>The index of the first occurrence of the specified element.</returns>
        public int IndexOf(T item)
        {
            Node? desiredNode = this.FindNode(item);
            if (desiredNode == null)
            {
                return -1;
            }

            int index = -1;
            Node current = this.head;

            for (int i = this.currentLevels - 1; i >= 0; --i)
            {
                while (current.Next[i] != null && this.comparer.Compare(current.Next[i].Value, item) < 0)
                {
                    index += current.Width[i];
                    current = current.Next[i];
                }

                if (current.Next[i] != null && this.comparer.Compare(current.Next[i].Value, item) == 0)
                {
                    if (i == 0 && current.Next[0] == desiredNode)
                    {
                        index += current.Width[0];
                        return index - current.Width[0];
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Inserts an item into the list at the specified index.
        /// </summary>
        /// <param name="index">Insertion index.</param>
        /// <param name="item">Element.</param>
        /// <exception cref="ArgumentOutOfRangeException">It is thrown if a negative starting position is specified.</exception>
        public void Insert(int index, T item)
        {
            if (index < 0 || index > this.count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int newLevel = this.GetRandomLevel();
            Node newNode = new Node(item, newLevel);
            Node[] update = new Node[newLevel];
            int[] steps = new int[newLevel];
            Node current = this.head;
            int pos = -1;

            for (int i = this.currentLevels - 1; i >= 0; --i)
            {
                while (current.Next[i] != null && this.comparer.Compare(current.Next[i].Value, item) < 0)
                {
                    pos += current.Width[i];
                    current = current.Next[i];
                }

                if (i < newLevel)
                {
                    update[i] = current;
                    steps[i] = pos + 1;
                }
            }

            if (newLevel > this.currentLevels)
            {
                for (int i = this.currentLevels; i < newLevel; ++i)
                {
                    this.head.Width[i] = this.count + 1;
                    update[i] = this.head;
                    steps[i] = 0;
                }

                this.currentLevels = newLevel;
            }

            for (int i = 0; i < newLevel; ++i)
            {
                newNode.Next[i] = update[i].Next[i];
                update[i].Next[i] = newNode;

                newNode.Width[i] = update[i].Width[i] - (index - (steps[i] == -1 ? 0 : steps[i]));
                update[i].Width[i] = (index - (steps[i] == -1 ? 0 : steps[i])) + 1;

                if (newNode.Next[i] != null)
                {
                    newNode.Width[i]--;
                }
            }

            for (int i = newLevel; i < this.currentLevels; ++i)
            {
                this.head.Width[i]++;
            }

            this.count++;
            this.version++;
        }

        /// <summary>
        /// Deletes the first occurrence of the specified element.
        /// </summary>
        /// <param name="item">Item to delete.</param>
        /// <returns>True if the element has been successfully deleted; otherwise, false.</returns>
        public bool Remove(T item)
        {
            Node? node = this.FindNode(item);
            if (node == null)
            {
                return false;
            }

            this.RemoveNode(node);
            return true;
        }

        /// <summary>
        /// Deletes an element by the specified index.
        /// </summary>
        /// <param name="index">Index of the item to delete.</param>
        /// <exception cref="ArgumentOutOfRangeException">It is thrown if a negative starting position is specified.</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node node = this.GetNodeAtIndex(index);
            this.RemoveNode(node);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list items.
        /// </summary>
        /// <returns>Enumerator of elements.</returns>
        /// <exception cref="InvalidOperationException">It is thrown if the collection has been changed.</exception>
        public IEnumerator<T> GetEnumerator()
        {
            int version = this.version;
            Node current = this.head.Next[0];

            while (current != null)
            {
                if (version != this.version)
                {
                    throw new InvalidOperationException();
                }

                yield return current.Value;
                current = current.Next[0];
            }
        }

        /// <summary>
        /// Implementation of the IEnumerable interface.
        /// </summary>
        /// <returns>Returns an enumerator of the IEnumerator type.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private Node? FindNode(T item)
        {
            Node current = this.head;
            for (int i = this.currentLevels - 1; i >= 0; --i)
            {
                while (current.Next[i] != null && this.comparer.Compare(current.Next[i].Value, item) < 0)
                {
                    current = current.Next[i];
                }
            }

            if (current.Next[0] != null && this.comparer.Compare(current.Next[0].Value, item) == 0)
            {
                return current.Next[0];
            }

            return null;
        }

        private Node GetNodeAtIndex(int index)
        {
            Node current = this.head;
            int currentIndex = -1;

            for (int i = this.currentLevels - 1; i >= 0; --i)
            {
                while (current.Next[i] != null && currentIndex + current.Width[i] <= index)
                {
                    currentIndex += current.Width[i];
                    current = current.Next[i];
                }
            }

            return current;
        }

        private void RemoveNode(Node node)
        {
            Node[] update = new Node[this.currentLevels];
            Node current = this.head;

            for (int i = this.currentLevels - 1; i >= 0; --i)
            {
                while (current.Next[i] != null && this.comparer.Compare(current.Next[i].Value, node.Value) < 0)
                {
                    current = current.Next[i];
                }

                update[i] = current;
            }

            for (int i = 0; i < this.currentLevels; ++i)
            {
                if (update[i].Next[i] == node)
                {
                    update[i].Width[i] += node.Width[i] - 1;
                    update[i].Next[i] = node.Next[i];
                }
                else
                {
                    update[i].Width[i]--;
                }
            }

            while (this.currentLevels > 1 && this.head.Next[this.currentLevels - 1] == null)
            {
                this.currentLevels--;
            }

            this.count--;
            this.version++;
        }

        private int GetRandomLevel()
        {
            int level = 1;
            while (this.random.NextDouble() < Probability && level < MaxLevel)
            {
                ++level;
            }

            return level;
        }

        private class Node
        {
            public Node(T value, int levels)
            {
                this.Value = value;
                this.Next = new Node[levels];
                this.Width = new int[levels];
            }

            public T Value { get; }

            public Node[] Next { get; }

            public int[] Width { get; }
        }
    }
}
