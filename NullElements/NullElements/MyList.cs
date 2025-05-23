// <copyright file="MyList.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

using System.Collections;

/// <summary>
/// Custom generic list implementation with dynamic resizing.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class MyList<T> : IEnumerable<T>
{
    private T[] items;

    private int count;

    /// <summary>
    /// Initializes a new instance of the <see cref="MyList{T}"/> class.
    /// </summary>
    public MyList()
    {
        this.items = new T[4];
        this.count = 0;
    }

    public int Count => this.count;

    /// <summary>
    /// Adds an item to the end of the list.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void Add(T item)
    {
        if (this.count == this.items.Length)
        {
            Array.Resize(ref this.items, this.items.Length == 0 ? 10 : this.items.Length * 2);
        }

        this.items[this.count] = item;
        this.count++;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator for the list.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.count; ++i)
        {
            yield return this.items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
