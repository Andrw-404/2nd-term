// <copyright file="SkipList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList
{
    using System.Collections;
    using System.Runtime.ExceptionServices;

    /// <summary>
    /// An implementation of a skip list that supports the IListT interface.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public class SkipList<T> : IList<T>
    {
        private const int MaxLevel = 32;
        private const double Probability = 0.5;

        private readonly Random random = new Random();
        private readonly IComparer<T> valueComparer;
        private readonly Node head = new Node(default, MaxLevel);

        private int currentLevels = 1;
        private int count;
        private int version;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
        /// </summary>
        public SkipList()
            : this(Comparer<T>.Default)
        {
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

            this.valueComparer = comparer;
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
        /// <exception cref="NotImplementedException">It is thrown when trying to set a value.</exception>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.GetNodeAtIndex(index).Value;
            }
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        /// <param name="item">The element to add.</param>
        public void Add(T item)
        {
            Node[] update = new Node[MaxLevel];
            int[] index = new int[MaxLevel];
            Node current = this.head;
            int currentIndex = -1;

            for (int i = this.currentLevels - 1; i >= 0; --i)
            {
                while (current.Next[i] != null && this.valueComparer.Compare(current.Next[i].Value, item) < 0)
                {
                    currentIndex += current.Width[i];
                    current = current.Next[i];
                }

                update[i] = current;
                index[i] = currentIndex;
            }

            int newLevel = this.GetRandomLevel();

            if (newLevel > this.currentLevels)
            {
                for (int i = this.currentLevels; i < newLevel; ++i)
                {
                    index[i] = -1;
                    update[i] = this.head;
                }

                this.currentLevels = newLevel;
            }

            Node newNode = new Node(item, newLevel);
            int addIndex = index[0] + 1;

            for (int i = 0; i < newLevel; ++i)
            {
                newNode.Next[i] = update[i].Next[i];
                update[i].Next[i] = newNode;

                int originalWidth = update[i].Width[i];
                int widthBefore = addIndex - index[i];
                int widthAfter = originalWidth - widthBefore;

                newNode.Width[i] = widthAfter;
                update[i].Width[i] = widthBefore;
            }

            for (int i = newLevel; i < this.currentLevels; ++i)
            {
                update[i].Width[i]++;
            }

            this.count++;
            this.version++;
        }

        /// <summary>
        /// Removes all items from the list.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < MaxLevel; ++i)
            {
                this.head.Next[i] = null;
                this.head.Width[i] = 0;
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
        public bool Contains(T item) => this.FindNodeByValue(item) != null;

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

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < this.count)
            {
                throw new ArgumentException();
            }

            Node current = this.head.Next[0];
            int i = arrayIndex;
            while (current != null)
            {
                array[i] = current.Value;
                current = current.Next[0];
                i++;
            }
        }

        /// <summary>
        /// Searching for the index of the first occurrence of the specified element.
        /// </summary>
        /// <param name="item">The desired element.</param>
        /// <returns>The index of the first occurrence of the specified element.</returns>
        public int IndexOf(T item)
        {
            Node current = this.head;
            int index = -1;

            for (int i = this.currentLevels - 1; i >= 0; --i)
            {
                while (current.Next[i] != null && this.valueComparer.Compare(current.Next[i].Value, item) < 0)
                {
                    index += current.Width[i];
                    current = current.Next[i];
                }
            }

            current = current.Next[0];

            if (current != null && this.valueComparer.Compare(current.Value, item) == 0)
            {
                return index + 1;
            }

            return -1;
        }

        /// <summary>
        /// Inserts an item into the list at the specified index.
        /// </summary>
        /// <param name="index">Insertion index.</param>
        /// <param name="item">Element.</param>
        /// <exception cref="NotImplementedException">It is thrown when trying to call the method.</exception>
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the first occurrence of the specified element.
        /// </summary>
        /// <param name="item">Item to delete.</param>
        /// <returns>True if the element has been successfully deleted; otherwise, false.</returns>
        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index != -1)
            {
                this.RemoveAt(index);
                return true;
            }

            return false;
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

            Node[] update = new Node[this.currentLevels];
            Node current = this.head;
            int currentIndex = -1;

            for (int i = this.currentLevels - 1; i >= 0; --i)
            {
                while (current.Next[i] != null && (currentIndex + current.Width[i]) < index)
                {
                    currentIndex += current.Width[i];
                    current = current.Next[i];
                }

                update[i] = current;
            }

            Node nodeToRemove = update[0].Next[0];

            if (nodeToRemove == null)
            {
                throw new InvalidDataException();
            }

            for (int i = 0; i < this.currentLevels; ++i)
            {
                if (update[i].Next[i] == nodeToRemove)
                {
                    update[i].Width[i] += nodeToRemove.Width[i] - 1;
                    update[i].Next[i] = nodeToRemove.Next[i];
                }
                else
                {
                    if (update[i].Width[i] > 0)
                    {
                        update[i].Width[i]--;
                    }
                }
            }

            while (this.currentLevels > 1 && this.head.Next[this.currentLevels - 1] == null)
            {
                this.currentLevels--;
            }

            this.count--;
            this.version++;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list items.
        /// </summary>
        /// <returns>Enumerator of elements.</returns>
        /// <exception cref="InvalidOperationException">It is thrown if the collection has been changed.</exception>
        public IEnumerator<T> GetEnumerator()
        {
            int startVersion = this.version;
            Node current = this.head.Next[0];

            while (current != null)
            {
                if (startVersion != this.version)
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

        private Node? FindNodeByValue(T value)
        {
            Node current = this.head;
            for (int i = this.currentLevels - 1; i >= 0; --i)
            {
                while (current.Next[i] != null && this.valueComparer.Compare(current.Next[i].Value, value) < 0)
                {
                    current = current.Next[i];
                }
            }

            if (current.Next[0] != null && this.valueComparer.Compare(current.Next[0].Value, value) == 0)
            {
                return current.Next[0];
            }

            return null;
        }

        private Node GetNodeAtIndex(int index)
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

            return current;
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
