// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree
{
    /// <summary>
    /// A class for representing a node in a tree.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Calculates the node value or the expression it represents.
        /// </summary>
        /// <returns>The value of the numeric node or the value of the expression that represents the node.</returns>
        public abstract int ValueOrExpression();

        /// <summary>
        /// Output of this node to the console.
        /// </summary>
        public abstract void Print();
    }
}