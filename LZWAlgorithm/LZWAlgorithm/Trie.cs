// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZWAlgorithm
{
    public class Trie
    {
        private readonly TrieNode root;
        private TrieNode current;
        private int nextCode;
        public int RootChildrenCount => root.Children.Count;

        public Trie()
        {
            this.root = new TrieNode();
            this.current = this.root;
            this.nextCode = 256;

            for (int i = 0; i < 256; i++)
            {
                this.AddNode(this.root, (byte)i, i);
            }
        }

        public void Reset() => this.current = this.root;

        public bool TryGetNextNode(byte b, out int code)
        {
            if (this.current.Children.TryGetValue(b, out var node))
            {
                this.current = node;
                code = -1;
                return true;
            }

            code = this.current.Code;
            var newNode = new TrieNode { Code = this.nextCode++ };
            this.current.Children[b] = newNode;
            this.current = this.root.Children[b];
            return false;
        }

        public int GetCurrentCode() => this.current.Code;

        private void AddNode(TrieNode parent, byte b, int code)
        {
            parent.Children[b] = new TrieNode { Code = code };
        }

        private class TrieNode
        {
            public Dictionary<byte, TrieNode> Children { get; } = new Dictionary<byte, TrieNode>();

            public int Code { get; set; }
        }
    }
}