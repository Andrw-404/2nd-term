// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZWAlgorithm
{
    /// <summary>
    /// The trie class with the required methods.
    /// </summary>
    public class Trie
    {
        private const int InitialDictionarySize = 256;
        private readonly TrieNode root;
        private TrieNode current;
        private int nextCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trie"/> class.
        /// Creates root node and initializes dictionary with all single-byte sequence.
        /// </summary>
        public Trie()
        {
            this.root = new TrieNode();
            this.current = this.root;
            this.nextCode = InitialDictionarySize;

            for (int i = 0; i < InitialDictionarySize; i++)
            {
                this.root.Children[(byte)i] = new TrieNode { Code = i };
            }
        }

        /// <summary>
        /// Gets the number of children nodes in the root (always 256 after initialization).
        /// </summary>
        public int RootChildrenCount => this.root.Children.Count;

        /// <summary>
        /// Gets the code of the current node during traversal.
        /// Returns -1 if current node is root.
        /// </summary>
        public int CurrentCode => this.current.Code;

        /// <summary>
        /// Resets the current node pointer to the root node.
        /// </summary>
        public void Reset() => this.current = this.root;

        /// <summary>
        /// Atempts to move to the next node in the Trie.
        /// </summary>
        /// <param name="b">The byte to add or move to.</param>
        /// <param name="code">Output parameter containing the code of the current sequence if a new node was created.</param>
        /// <returns>
        /// True, if the node exists;
        /// False if the node was created and the sequence code is returned.
        /// </returns>
        public bool TryMoveNextOrAdd(byte b, out int code)
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

        /// <summary>
        /// Adds a new child node to the specified parent node.
        /// </summary>
        /// <param name="parent">Parent node to add child.</param>
        /// <param name="b">Byte value for the new node.</param>
        /// <param name="code">Code to assign to the new node.</param>
        private void AddNode(TrieNode parent, byte b, int code)
        {
            parent.Children[b] = new TrieNode { Code = code };
        }

        /// <summary>
        /// Represents a node in the Trie data structure.
        /// </summary>
        private class TrieNode
        {
            public Dictionary<byte, TrieNode> Children { get; } = new Dictionary<byte, TrieNode>();

            public int Code { get; set; } = -1;
        }
    }
}