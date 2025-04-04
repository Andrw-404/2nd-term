// <copyright file="AdditionNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree
{
    public class AdditionNode : Node
    {
        private Node left;
        private Node right;
        public AdditionNode(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        public override int ValueOrExpression() => left.ValueOrExpression() + right.ValueOrExpression();

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
