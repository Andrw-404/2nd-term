// <copyright file="IntNullChecker.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace NullElements
{
    /// <summary>
    /// Null-equivalence checker for integer values.
    /// </summary>
    public class IntNullChecker : ICheckNulls<int>
    {
        /// <summary>
        /// Determines if an integer is zero.
        /// </summary>
        /// <param name="item">The integer to check.</param>
        /// <returns>True if the value is zero, otherwise False.</returns>
        public bool IsNull(int item) => item == 0;
    }
}
