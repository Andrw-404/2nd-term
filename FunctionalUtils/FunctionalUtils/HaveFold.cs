// <copyright file="HaveFold.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace FunctionalUtils;

/// <summary>
/// A class for implementing the Fold function.
/// </summary>
public static class HaveFold
{
    /// <summary>
    /// A function for calculating the accumulated value by processing each list item.
    /// </summary>
    /// <typeparam name="T">Type of list items.</typeparam>
    /// <typeparam name="TAccumulator">The type of the accumulator value.</typeparam>
    /// <param name="inputList">Incoming list.</param>
    /// <param name="initialValue">Incoming accumulated value.</param>
    /// <param name="function">The accumulation function.</param>
    /// <returns>The final accumulated value.</returns>
    public static TAccumulator Fold<T, TAccumulator>(List<T> inputList, TAccumulator initialValue, Func<TAccumulator, T, TAccumulator> function)
    {
        var accumulator = initialValue;
        foreach (var i in inputList)
        {
            accumulator = function(accumulator, i);
        }

        return accumulator;
    }
}