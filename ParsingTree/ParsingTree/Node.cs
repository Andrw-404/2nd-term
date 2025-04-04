// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree
{
    public abstract class Node
    {
        public abstract int ValueOrExpression();
        public abstract void Print();
    }
}