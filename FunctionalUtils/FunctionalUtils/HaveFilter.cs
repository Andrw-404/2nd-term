// <copyright file="HaveFilter.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace FunctionalUtils;

/// <summary>
/// A class for implementing the Filter function.
/// </summary>
public static class HaveFilter
{
    /// <summary>
    /// Filters the incoming list using the incoming function.
    /// </summary>
    /// <typeparam name="T">Type of list items.</typeparam>
    /// <param name="inputList">Incoming list.</param>
    /// <param name="function">A function that is applied to each element of the list and indicates the elements we need.</param>
    /// <returns>A new list containing the elements satisfying the function.</returns>
    public static List<T> Filter<T>(List<T> inputList, Func<T, bool> function)
    {
        var newList = new List<T>();
        foreach (var i in inputList)
        {
            if (function(i))
            {
                newList.Add(i);
            }
        }

        return newList;
    }
}
