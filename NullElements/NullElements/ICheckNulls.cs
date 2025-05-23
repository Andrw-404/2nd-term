// <copyright file="ICheckNulls.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace NullElements
{
    /// <summary>
    /// Interface for checking if elements meet null-equivalent conditions.
    /// </summary>
    /// <typeparam name="T">The type of elements to check.</typeparam>
    public interface ICheckNulls<T>
    {
        /// <summary>
        /// Determines if an item should be considered null-equivalent.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>True if the item is considered null-equivalent, otherwise False.</returns>
        bool IsNull(T item);
    }
}
