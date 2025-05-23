// <copyright file="Counter.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace NullElements
{
    /// <summary>
    /// Provides utility methods for working with collections.
    /// </summary>
    public static class Counter
    {
        /// <summary>
        /// Counts elements that match null-equivalent conditions.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The collection to inspect.</param>
        /// <param name="checker">The null-equivalence checker implementation.</param>
        /// <returns>The number of null-equivalent elements.</returns>
        /// <exception cref="ArgumentNullException">Thrown when list or checker is null.</
        public static int CountNulls<T>(MyList<T> list, ICheckNulls<T> checker)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (checker == null)
            {
                throw new ArgumentNullException(nameof(checker));
            }

            int count = 0;

            foreach (var item in list)
            {
                if (checker.IsNull(item))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
