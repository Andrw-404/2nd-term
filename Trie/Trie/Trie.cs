// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// the trie class with the required methods.
/// </summary>
public class Trie
{
    private readonly TrieNode root = new ();
    private int countOfWords;

    /// <summary>
    /// Gets the number of words in the Trie.
    /// </summary>
    public int Size => this.countOfWords;

    /// <summary>
    /// a method for adding elements to a trie.
    /// </summary>
    /// <param name="element">the string to add.</param>
    /// <returns>True, if the string was successfully added; False, if the string was already in the trie.</returns>
    /// <exception cref="ArgumentNullException">triggered if <paramref name="element"/> is null. </exception>
    public bool Add(string element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element));
        }

        if (this.Contains(element))
        {
            return false;
        }

        TrieNode current = this.root;
        current.PrefixCount++;

        foreach (char symbol in element)
        {
            if (!current.Children.TryGetValue(symbol, out TrieNode? next))
            {
                next = new TrieNode();
                current.Children[symbol] = next;
            }

            current = next;
            current.PrefixCount++;
        }

        current.IsEnd = true;
        this.countOfWords++;
        return true;
    }

    /// <summary>
    /// checks for presence in the trie.
    /// </summary>
    /// <param name="element">the string to check.</param>
    /// <returns>True, if the element is contained, otherwise False.</returns>
    public bool Contains(string element)
    {
        if (element == null)
        {
            return false;
        }

        TrieNode? current = this.root;
        foreach (char symbol in element)
        {
            if (!current.Children.TryGetValue(symbol, out current) || current == null)
            {
                return false;
            }
        }

        return current.IsEnd;
    }

    /// <summary>
    /// removes an element from the trie.
    /// </summary>
    /// <param name="element">the string to delete.</param>
    /// <returns>True, if the string was successfully deleted; False, if the string has a null value or is not contained in trie.</returns>
    public bool Remove(string element)
    {
        if (element == null || !this.Contains(element))
        {
            return false;
        }

        TrieNode current = this.root;
        List<TrieNode> way = new List<TrieNode>() { current };

        foreach (char symbol in element)
        {
            current = current.Children[symbol];
            way.Add(current);
        }

        current.IsEnd = false;
        this.countOfWords--;

        foreach (var node in way)
        {
            node.PrefixCount--;
        }

        for (int i = way.Count - 1; i > 0; i--)
        {
            if (way[i].PrefixCount == 0)
            {
                char symbol = element[i - 1];
                way[i - 1].Children.Remove(symbol);
            }
        }

        return true;
    }

    /// <summary>
    /// returns word count that started with specified prefix.
    /// </summary>
    /// <param name="prefix">the prefix for the search.</param>
    /// <returns>the number of words starting with <paramref name="prefix"/>.</returns>
    /// <remarks>
    /// if <paramref name="prefix"/> is null, then zero is returned.
    /// </remarks>
    public int HowManyStartsWithPrefix(string prefix)
    {
        if (prefix == null)
        {
            return 0;
        }

        TrieNode? current = this.root;

        foreach (char symbol in prefix)
        {
            if (!current.Children.TryGetValue(symbol, out current) || current == null)
            {
                return 0;
            }
        }

        return current.PrefixCount;
    }

    /// <summary>
    /// a node in the trie.
    /// </summary>
    private class TrieNode
    {
        /// <summary>
        /// Gets the child nodes (the key is the symbol, the value is the next node).
        /// </summary>
        public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();

        /// <summary>
        /// Gets or sets a value indicating whether the node is the end of a word.
        /// </summary>
        public bool IsEnd { get; set; }

        /// <summary>
        /// Gets or sets the nnumber of words that use this node as a prefix.
        /// </summary>
        public int PrefixCount { get; set; }
    }
}