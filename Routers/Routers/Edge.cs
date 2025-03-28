// <copyright file="Edge.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers
{
    public class Edge
    {
        public int Start { get; }
        public int End { get; }
        public int Weight { get; }

        public Edge(int start, int end, int weight)
        {
            this.Start = start;
            this.End = end;
            this.Weight = weight;
        }
    }
}
