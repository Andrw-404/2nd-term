// <copyright file="DivisionNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree
{
    class DivisionNode : Node
    {
        private Node left;
        private Node right;

        public DivisionNode(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        public override int ValueOrExpression()
        {
            int rightValue = this.right.ValueOrExpression();
            if (rightValue == 0)
            {
                throw new DivideByZeroException("division by zero ");
            }

            return this.left.ValueOrExpression() / rightValue;
        }

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