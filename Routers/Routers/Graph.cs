// <copyright file="Graph.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Graph representation.
/// </summary>
public class Graph
{
    private readonly List<Edge> edges = new List<Edge>();
    private readonly HashSet<int> vertexes = new HashSet<int>();

    /// <summary>
    /// Gets all the edges.
    /// </summary>
    public IEnumerable<Edge> GetAllEdges => this.edges;

    /// <summary>
    /// Gets all vertices.
    /// </summary>
    public IEnumerable<int> GetAllVertexes => this.vertexes;

    /// <summary>
    /// Add an edge to the graph.
    /// </summary>
    /// <param name="newEdge">A new edge.</param>
    public void AddEdges(Edge newEdge)
    {
        this.edges.Add(newEdge);
        this.vertexes.Add(newEdge.Start);
        this.vertexes.Add(newEdge.End);
    }

    /// <summary>
    /// Get adjacent edges.
    /// </summary>
    /// <param name="vertex">Graph vertex(digit).</param>
    /// <returns>Returns the edges connected to the specified vertex.</returns>
    public IEnumerable<Edge> GetAdjacentEdges(int vertex) =>
        this.edges.Where(edge => edge.Start == vertex || edge.End == vertex);
}
