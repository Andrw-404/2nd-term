// <copyright file="MultiplyingNode.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// A class representing the product of two numbers.
/// </summary>
public class MultiplyingNode : Node
{
    private Node left;
    private Node right;

    /// <summary>
    /// Initializes a new instance of the <see cref="MultiplyingNode"/> class.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    public MultiplyingNode(Node left, Node right)
    {
        this.left = left;
        this.right = right;
    }

    /// <summary>
    /// Calculates the product of the left and right operands.
    /// </summary>
    /// <returns>The result of the multiplication.</returns>
    public override int ValueOrExpression() => this.left.ValueOrExpression() * this.right.ValueOrExpression();

    /// <summary>
    /// Output of the subtraction node to the console.
    /// </summary>
    public override void Print()
    {
        Console.Write("(* ");
        this.left.Print();
        Console.Write(" ");
        this.right.Print();
        Console.Write(")");
    }
}
