// <copyright file="LZW.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZWAlgorithm
{
    public static class LZW
    {
        public static int[] Compress(byte[] input)
        {
            var trie = new Trie();
            var codes = new List<int>();
            trie.Reset();

            foreach (byte b in input)
            {
                if (!trie.TryGetNextNode(b, out int code))
                {
                    codes.Add(code);
                }
            }

            if (trie.GetCurrentCode() != -1)
            {
                codes.Add(trie.GetCurrentCode());
            }

            return codes.ToArray();
        }

        public static byte[] Decompress(int[] codes)
        {
            if (codes.Length == 0)
            {
                return Array.Empty<byte>();
            }

            var dictionary = new Dictionary<int, List<byte>>();
            for (int i = 0; i < 256; i++)
            {
                dictionary[i] = new List<byte> { (byte)i };
            }

            var output = new List<byte>();
            int prevCode = codes[0];
            output.AddRange(dictionary[prevCode]);

            for (int i = 1; i < codes.Length; i++)
            {
                int code = codes[i];
                List<byte> entry;

                if (dictionary.TryGetValue(code, out entry))
                {
                    output.AddRange(entry);
                }
                else if (code == dictionary.Count)
                {
                    entry = new List<byte>(dictionary[prevCode]) { dictionary[prevCode][0] };
                    output.AddRange(entry);
                }
                else
                {
                    throw new InvalidOperationException("Недопустимый код LZW");
                }

                var newEntry = new List<byte>(dictionary[prevCode]) { entry[0] };
                dictionary.Add(dictionary.Count, newEntry);
                prevCode = code;
            }

            return output.ToArray();
        }
    }
}