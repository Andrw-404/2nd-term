// <copyright file="NumberNode.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Represents an integer in the tree.
/// </summary>
public class NumberNode : Node
{
    private int value;

    /// <summary>
    /// Initializes a new instance of the <see cref="NumberNode"/> class.
    /// </summary>
    /// <param name="value">The integer that represents the node.</param>
    public NumberNode(int value) => this.value = value;

    /// <summary>
    /// Returns the number that represents the node.
    /// </summary>
    /// <returns>Number that represents the node.</returns>
    public override int ValueOrExpression() => this.value;

    /// <summary>
    /// Outputs to the console the number that represents the node.
    /// </summary>
    public override void Print() => Console.Write(this.value);
}
