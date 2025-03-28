// <copyright file="Graph.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers
{
    public class Graph
    {
        private readonly List<Edge> edges = new List<Edge>();
        private readonly HashSet<int> vertexes = new HashSet<int>();
        public IEnumerable<Edge> GetAllEdges => this.edges;
        public IEnumerable<int> GetAllVertexes => this.vertexes;

        public void addEdges(Edge newEdge)
        {
            this.edges.Add(newEdge);
            this.vertexes.Add(newEdge.Start);
            this.vertexes.Add(newEdge.End);
        }

        public IEnumerable<Edge> GetAdjacentEdges(int vertex) => 
            this.edges.Where(edge => edge.Start == vertex || edge.End == vertex);
    }
}
