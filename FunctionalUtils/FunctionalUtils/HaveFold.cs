// <copyright file="HaveFold.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FunctionalUtils
{
    /// <summary>
    /// A class for implementing the Fold function.
    /// </summary>
    public class HaveFold
    {
        /// <summary>
        /// A function for calculating the accumulated value by processing each list item.
        /// </summary>
        /// <typeparam name="T">Type of list items.</typeparam>
        /// <typeparam name="TAcc">The type of the accumulator value.</typeparam>
        /// <param name="inputList">Incoming list.</param>
        /// <param name="start">Incoming accumulated value.</param>
        /// <param name="function">The accumulation function.</param>
        /// <returns>The final accumulated value.</returns>
        public static TAcc Fold<T, TAcc>(List<T> inputList, TAcc start, Func<TAcc, T, TAcc> function)
        {
            var acc = start;
            foreach (var i in inputList)
            {
                acc = function(acc, i);
            }

            return acc;
        }
    }
}