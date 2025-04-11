// <copyright file="Queue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PriorityQueue
{
    /// <summary>
    /// The class that implements the queue.
    /// </summary>
    /// <typeparam name="T">The type of the element value.</typeparam>
    public class Queue<T>
    {
        private QueueNode<T>[] items;
        private int count;
        private int sequence;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// Constructor with initial capacity.
        /// </summary>
        public Queue()
        {
            this.items = new QueueNode<T>[10];
            this.count = 0;
            this.sequence = 0;
        }

        /// <summary>
        /// Gets a value indicating whether gets whether the queue is empty or not.
        /// </summary>
        public bool Empty => this.count == 0;

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <param name="value">Node value.</param>
        /// <param name="priority">Node priority.</param>
        public void Enqueue(T value, int priority)
        {
            if (this.count == this.items.Length)
            {
                Array.Resize(ref this.items, this.items.Length * 2);
            }

            this.items[this.count] = new QueueNode<T>(value, priority, this.sequence);
            this.sequence++;
            this.count++;
        }

        /// <summary>
        /// A method that returns the value with the highest priority and deletes it from the queue.
        /// </summary>
        /// <returns>The value with the highest priority.</returns>
        /// <exception cref="InvalidDataException">It is thrown if the queue is empty.</exception>
        public T Dequeue()
        {
            if (this.Empty)
            {
                throw new InvalidDataException("Queue is empty");
            }

            int maxIndex = 0;
            for (int i = 0; i < this.count; ++i)
            {
                if (this.CompareNodes(this.items[i], this.items[maxIndex]) > 0)
                {
                    maxIndex = i;
                }
            }

            var result = this.items[maxIndex].Value;

            for (int i = maxIndex; i < this.count - 1; ++i)
            {
                this.items[i] = this.items[i + 1];
            }

            this.count--;
            return result;
        }

        /// <summary>
        /// Comparing two nodes.
        /// </summary>
        /// <param name="first">First node.</param>
        /// <param name="second">Second node.</param>
        /// <returns>A signed integer that indicates whether a given instance is located before, after, or at the same position in the sorting order.</returns>
        private int CompareNodes(QueueNode<T> first, QueueNode<T> second)
        {
            if (first.Priority != second.Priority)
            {
                return second.Priority.CompareTo(first.Priority);
            }

            return second.Sequence.CompareTo(first.Sequence);
        }
    }
}
