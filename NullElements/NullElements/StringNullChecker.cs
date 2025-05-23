// <copyright file="StringNullChecker.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace NullElements
{
    /// <summary>
    /// Null-equivalence checker for string values
    /// </summary>
    public class StringNullChecker : ICheckNulls<string>
    {
        /// <summary>
        /// Determines if a string is null or empty.
        /// </summary>
        /// <param name="item">The string to check.</param>
        /// <returns>True for null or empty strings, otherwise False.</returns>
        public bool IsNull(string item) => item == null || item == string.Empty;
    }
}
