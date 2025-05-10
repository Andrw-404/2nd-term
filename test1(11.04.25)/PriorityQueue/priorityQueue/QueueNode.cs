// <copyright file="QueueNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PriorityQueue
{
    /// <summary>
    /// Priority queue element.
    /// </summary>
    /// <typeparam name="T">Type of stored value.</typeparam>
    public struct QueueNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueNode{T}"/> struct.
        /// Node constructor.
        /// </summary>
        /// <param name="value">Node value.</param>
        /// <param name="priority">Node priority.</param>
        /// <param name="sequence">The sequence number of the node.</param>
        public QueueNode(T value, int priority, int sequence)
        {
            this.Value = value;
            this.Priority = priority;
            this.Sequence = sequence;
        }

        /// <summary>
        /// Gets value of node.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Gets priority of node.
        /// </summary>
        public int Priority { get; }

        /// <summary>
        /// Gets sequence of node.
        /// </summary>
        public int Sequence { get; }
    }
}
