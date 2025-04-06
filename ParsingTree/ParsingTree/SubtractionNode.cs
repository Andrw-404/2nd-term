// <copyright file="SubtractionNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree
{
    /// <summary>
    /// A class for representing the subtraction node.
    /// </summary>
    public class SubtractionNode : Node
    {
        private Node left;
        private Node right;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractionNode"/> class.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public SubtractionNode(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Calculates the difference between the left and right operands.
        /// </summary>
        /// <returns>The result of the subtraction.</returns>
        public override int ValueOrExpression() => this.left.ValueOrExpression() - this.right.ValueOrExpression();

        /// <summary>
        /// Output of the subtraction node to the console.
        /// </summary>
        public override void Print()
        {
            Console.Write("(- ");
            this.left.Print();
            Console.Write(" ");
            this.right.Print();
            Console.Write(")");
        }
    }
}