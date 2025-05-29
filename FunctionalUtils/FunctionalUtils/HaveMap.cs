// <copyright file="HaveMap.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace FunctionalUtils;

/// <summary>
/// A class for implementing the Map function.
/// </summary>
public static class HaveMap
{
    /// <summary>
    /// Applies an incoming function to each item in the incoming list.
    /// </summary>
    /// <typeparam name="T">The type of the incoming list items.</typeparam>
    /// <typeparam name="TResult">The type of the elements in the resulting list.</typeparam>
    /// <param name="inputList">Incoming list.</param>
    /// <param name="function">The function that will be applied to each element of the input list.</param>
    /// <returns>The list transformed by the function.</returns>
    public static List<TResult> Map<T, TResult>(List<T> inputList, Func<T, TResult> function)
    {
        var newList = new List<TResult>();
        foreach (var i in inputList)
        {
            newList.Add(function(i));
        }

        return newList;
    }
}