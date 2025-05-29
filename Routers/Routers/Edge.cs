// <copyright file="Edge.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace Routers
{
    /// <summary>
    /// A class for representing graph edges.
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Edge"/> class.
        /// Initializing a new edge.
        /// </summary>
        /// <param name="start">The beginning of the edge(the router).</param>
        /// <param name="end">Edge end(the router).</param>
        /// <param name="weight">Edge weight(in our case, the bandwidth).</param>
        public Edge(int start, int end, int weight)
        {
            this.Start = start;
            this.End = end;
            this.Weight = weight;
        }

        /// <summary>
        /// Gets the initial vertex of the edge.
        /// </summary>
        public int Start { get; }

        /// <summary>
        /// Gets the final vertex of the edge.
        /// </summary>
        public int End { get; }

        /// <summary>
        /// Gets edge weight (bandwidth).
        /// </summary>
        public int Weight { get; }
    }
}
