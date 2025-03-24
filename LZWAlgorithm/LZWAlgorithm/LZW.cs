// <copyright file="LZW.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZWAlgorithm
{
    /// <summary>
    /// Implementation of the LZW compression algorithm.
    /// </summary>
    public static class LZW
    {
        /// <summary>
        /// The initial size of the dictionary (256 elements for all possible bytes).
        /// </summary>
        private const int InitialDictionarySize = 256;

        /// <summary>
        /// Compresses an array of bytes using the LZW algorithm.
        /// </summary>
        /// <param name="input">Input byte array for compression.</param>
        /// <returns>An array of integers representing compressed codes.</returns>
        public static int[] Compress(byte[] input)
        {
            var trie = new Trie();
            var codes = new List<int>();

            foreach (byte b in input)
            {
                if (!trie.TryMoveNextOrAdd(b, out int code))
                {
                    codes.Add(code);
                }
            }

            int currentCode = trie.CurrentCode;
            if (currentCode != -1)
            {
                codes.Add(currentCode);
            }

            return codes.ToArray();
        }

        /// <summary>
        /// Decompresses an array of LZW codes into the source data.
        /// </summary>
        /// <param name="codes">An array of compressed codes.</param>
        /// <returns>Decompressed byte array.</returns>
        /// <exception cref="InvalidOperationException">
        /// It is thrown when an invalid code is detected.
        /// </exception>
        public static byte[] Decompress(int[] codes)
        {
            if (codes.Length == 0)
            {
                return Array.Empty<byte>();
            }

            var codeTable = new List<List<byte>>();
            for (int i = 0; i < InitialDictionarySize; i++)
            {
                codeTable.Add(new List<byte> { (byte)i });
            }

            var output = new List<byte>();
            int prevCode = codes[0];
            output.AddRange(codeTable[prevCode]);

            for (int i = 1; i < codes.Length; i++)
            {
                int code = codes[i];
                List<byte> entry;

                if (code < codeTable.Count)
                {
                    entry = codeTable[code];
                }
                else if (code == codeTable.Count)
                {
                    entry = new List<byte>(codeTable[prevCode]) { codeTable[prevCode][0] };
                }
                else
                {
                    throw new InvalidOperationException("Недопустимый код LZW");
                }

                output.AddRange(entry);
                codeTable.Add(new List<byte>(codeTable[prevCode]) { entry[0] });
                prevCode = code;
            }

            return output.ToArray();
        }
    }
}
