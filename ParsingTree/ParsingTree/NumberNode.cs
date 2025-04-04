// <copyright file="NumberNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree
{
    public class NumberNode : Node
    {
        private int value;
        public NumberNode(int value)
        {
            this.value = value;
        }

        public override int ValueOrExpression() => this.value;

        public override void Print() => Console.Write(this.value);
    }
}
