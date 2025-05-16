// <copyright file="MyLinqMethods.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace MyLinqMethods
{
    /// <summary>
    /// A class that provides methods for working with sequences.
    /// </summary>
    public static class MyLinqMethods
    {
        /// <summary>
        /// A method for obtaining an infinite sequence of prime numbers.
        /// </summary>
        /// <returns>Infinite sequence of prime numbers.</returns>
        public static IEnumerable<int> GetPrimes()
        {
            int number = 2;
            while (true)
            {
                if (IsPrime(number))
                {
                    yield return number;
                }

                number++;
            }
        }

        /// <summary>
        /// A method for obtaining a sequence of the first n elements of a given sequence.
        /// </summary>
        /// <typeparam name="T">The type of sequence elements.</typeparam>
        /// <param name="seq">Sequence.</param>
        /// <param name="n">The number of the first necessary elements.</param>
        /// <returns>The resulting subsequence.</returns>
        /// <exception cref="ArgumentOutOfRangeException">It is thrown if the number of elements is zero or a negative number.</exception>
        public static IEnumerable<T> Take<T>(this IEnumerable<T> seq, int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (seq == null)
            {
                throw new ArgumentNullException();
            }

            int count = 0;

            foreach (var item in seq)
            {
                if (count < n)
                {
                    yield return item;
                    count++;
                }
                else
                {
                    yield break;
                }
            }
        }

        /// <summary>
        /// Skips the first n elements of the sequence.
        /// </summary>
        /// <typeparam name="T">The type of sequence elements.</typeparam>
        /// <param name="seq">Sequence.</param>
        /// <param name="n">The number of items to skip.</param>
        /// <returns>A sequence without the first n elements.</returns>
        public static IEnumerable<T> Skip<T>(this IEnumerable<T> seq, int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (seq == null)
            {
                throw new ArgumentNullException();
            }

            using (IEnumerator<T> enumerator = seq.GetEnumerator())
            {
                int skipped = 0;
                while (skipped < n && enumerator.MoveNext())
                {
                    skipped++;
                }

                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}