// <copyright file="DivisionNode.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace ParsingTree
{
    /// <summary>
    /// A class for representing the division node.
    /// </summary>
    public class DivisionNode : Node
    {
        private Node left;
        private Node right;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionNode"/> class.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public DivisionNode(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Calculates the value that represents the division node.
        /// </summary>
        /// <returns>The quotient of two numbers.</returns>
        /// <exception cref="DivideByZeroException">It is thrown if the right operand is zero.</exception>
        public override int ValueOrExpression()
        {
            int rightValue = this.right.ValueOrExpression();
            if (rightValue == 0)
            {
                throw new DivideByZeroException("division by zero ");
            }

            return this.left.ValueOrExpression() / rightValue;
        }

        /// <summary>
        /// Output of the division node to the console.
        /// </summary>
        public override void Print()
        {
            Console.Write("(/ ");
            this.left.Print();
            Console.Write(" ");
            this.right.Print();
            Console.Write(")");
        }
    }
}