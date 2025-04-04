// <copyright file="SubtractionNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree
{
    public class SubtractionNode : Node
    {
        private Node left;
        private Node right;
        public SubtractionNode(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        public override int ValueOrExpression() => this.left.ValueOrExpression() - this.right.ValueOrExpression();

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