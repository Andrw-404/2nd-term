// <copyright file="OutputTests.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace Routers.Tests;

public class OutputTests
{
    [Test]
    public void TransformationMst_CorrectMST_ShouldReturnCorrectForm()
    {
        var graph = new List<Edge>()
        {
            new Edge(1, 2, 10),
            new Edge(2, 3, 1),
            new Edge(1, 3, 5),
        };

        string result = Output.TransformationMst(graph);
        string expected =
            "1: 2 (10), 3 (5)\n" +
            "2: 3 (1)";

        Assert.That(result, Is.EqualTo(expected));
    }
}
