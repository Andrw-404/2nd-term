// <copyright file="AdditionNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree
{
    /// <summary>
    /// A class for representing the addition node.
    /// </summary>
    public class AdditionNode : Node
    {
        private Node left;
        private Node right;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionNode"/> class.
        /// Adding operands to an addition node.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public AdditionNode(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Counts the sum of the left and right operands.
        /// </summary>
        /// <returns>Amount(integer).</returns>
        public override int ValueOrExpression() => this.left.ValueOrExpression() + this.right.ValueOrExpression();

        /// <summary>
        /// Output of the addition node to the console.
        /// </summary>
        public override void Print()
        {
            Console.Write("(+ ");
            this.left.Print();
            Console.Write(" ");
            this.right.Print();
            Console.Write(")");
        }
    }
}
