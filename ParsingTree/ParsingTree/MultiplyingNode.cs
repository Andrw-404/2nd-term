// <copyright file="MultiplyingNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree
{
    public class MultiplyingNode : Node
    {
        private Node left;
        private Node right;
        public MultiplyingNode(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        public override int ValueOrExpression() => this.left.ValueOrExpression() * this.right.ValueOrExpression();

        public override void Print()
        {
            Console.Write("(* ");
            this.left.Print();
            Console.Write(" ");
            this.right.Print();
            Console.Write(")");
        }
    }
}
