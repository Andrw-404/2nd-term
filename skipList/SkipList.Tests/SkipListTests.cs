// <copyright file="SkipListTests.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace SkipList.Tests;

public class SkipListTests
{
    [Test]
    public void Count_SequentialAdditionNumbers_ShouldReturnCorrectQuantity()
    {
        var testSkipList = new SkipList<int>();
        testSkipList.Add(10);
        Assert.That(testSkipList.Count, Is.EqualTo(1));
        testSkipList.Add(20);
        Assert.That(testSkipList.Count, Is.EqualTo(2));
    }

    [Test]
    public void Count_SequentialAdditionChars_ShouldReturnCorrectQuantity()
    {
        var testSkipList = new SkipList<char>();
        testSkipList.Add('a');
        Assert.That(testSkipList.Count, Is.EqualTo(1));
        testSkipList.Add('b');
        Assert.That(testSkipList.Count, Is.EqualTo(2));
    }

    [Test]
    public void Count_SequentialAdditionStrings_ShouldReturnCorrectQuantity()
    {
        var testSkipList = new SkipList<string>();
        testSkipList.Add("abcde");
        Assert.That(testSkipList.Count, Is.EqualTo(1));
        testSkipList.Add("fghij");
        Assert.That(testSkipList.Count, Is.EqualTo(2));
    }

    [Test]
    public void GetByIndex_TheCorrectList_ShouldReturnCorrectValue()
    {
        var testSkipList = new SkipList<int>();
        testSkipList.Add(1);
        testSkipList.Add(2);
        testSkipList.Add(3);

        Assert.That(testSkipList[0], Is.EqualTo(1));
        Assert.That(testSkipList[1], Is.EqualTo(2));
        Assert.That(testSkipList[2], Is.EqualTo(3));
    }

    [Test]
    public void Add_SequentialAdditionChars_ShouldReturnCorrectElements()
    {
        var testSkipList = new SkipList<char>();
        testSkipList.Add('a');
        testSkipList.Add('b');
        testSkipList.Add('c');

        Assert.That(testSkipList[0], Is.EqualTo('a'));
        Assert.That(testSkipList[1], Is.EqualTo('b'));
        Assert.That(testSkipList[2], Is.EqualTo('c'));
    }

    [Test]
    public void Clear_CorrectList_ShouldReturnFalseForContains()
    {
        var testSkipList = new SkipList<char>();
        testSkipList.Add('a');
        testSkipList.Add('b');
        testSkipList.Add('c');
        Assert.That(testSkipList.Count, Is.EqualTo(3));

        testSkipList.Clear();
        Assert.That(testSkipList.Count, Is.EqualTo(0));

        Assert.That(testSkipList.Contains('a'), Is.False);
    }

    [Test]
    public void Contains_ExistingValue_ShouldReturnTrue()
    {
        var testSkipList = new SkipList<string>();
        testSkipList.Add("adcc");
        testSkipList.Add("dsads");

        Assert.That(testSkipList.Contains("adcc"), Is.True);
        Assert.That(testSkipList.Contains("dsads"), Is.True);
    }

    [Test]
    public void Contains_NonExistingValue_ShouldReturnFalse()
    {
        var testSkipList = new SkipList<string>();
        testSkipList.Add("adcc");
        testSkipList.Add("dsads");

        Assert.That(testSkipList.Contains("gfdh"), Is.False);
    }

    [Test]
    public void CopyTo_CorrectData_ShouldCopyItCorrectly()
    {
        var testSkipList = new SkipList<int>();
        testSkipList.Add(1);
        testSkipList.Add(2);
        testSkipList.Add(3);

        Assert.That(testSkipList.Count, Is.EqualTo(3));

        int[] array = new int[3];

        testSkipList.CopyTo(array, 0);

        Assert.That(array[0], Is.EqualTo(1));
        Assert.That(array[1], Is.EqualTo(2));
        Assert.That(array[2], Is.EqualTo(3));
    }

    [Test]
    public void IndexOf_ExistingValue_ShouldReturnCorrectIndex()
    {
        var testSkipList = new SkipList<int>();
        testSkipList.Add(1);
        testSkipList.Add(2);
        testSkipList.Add(3);

        Assert.That(testSkipList.IndexOf(1), Is.EqualTo(0));
        Assert.That(testSkipList.IndexOf(2), Is.EqualTo(1));
        Assert.That(testSkipList.IndexOf(3), Is.EqualTo(2));
    }

    [Test]
    public void IndexOf_RepeatedValue_ShouldReturnCorrectIndex()
    {
        var testSkipList = new SkipList<int>();
        testSkipList.Add(1);
        testSkipList.Add(2);
        testSkipList.Add(1);

        Assert.That(testSkipList.IndexOf(1), Is.EqualTo(0));
    }

    [Test]
    public void Remove_ExistingValue_ShouldReturnTrueAndListCountShouldBeEqualToTwo()
    {
        var testSkipList = new SkipList<char>();
        testSkipList.Add('a');
        testSkipList.Add('b');
        testSkipList.Add('c');

        Assert.That(testSkipList.Count, Is.EqualTo(3));

        Assert.That(testSkipList.IndexOf('a'), Is.EqualTo(0));
        Assert.That(testSkipList.IndexOf('b'), Is.EqualTo(1));
        Assert.That(testSkipList.IndexOf('c'), Is.EqualTo(2));

        bool res = testSkipList.Remove('b');
        Assert.That(res, Is.True);

        Assert.That(testSkipList.Count, Is.EqualTo(2));

        Assert.That(testSkipList.Contains('b'), Is.False);
    }

    [Test]
    public void Remove_NonExistingValue_ShouldReturnFalse()
    {
        var testSkipList = new SkipList<char>();
        testSkipList.Add('a');
        testSkipList.Add('b');
        testSkipList.Add('c');

        Assert.That(testSkipList.Count, Is.EqualTo(3));

        Assert.That(testSkipList.IndexOf('a'), Is.EqualTo(0));
        Assert.That(testSkipList.IndexOf('b'), Is.EqualTo(1));
        Assert.That(testSkipList.IndexOf('c'), Is.EqualTo(2));

        bool res = testSkipList.Remove('d');
        Assert.That(res, Is.False);

        Assert.That(testSkipList.Count, Is.EqualTo(3));
    }

    [Test]
    public void RemoveAt_CorrectIndex_ShouldReturnTrueAndListCountShouldBeEqualToTwo()
    {
        var testSkipList = new SkipList<int>();
        testSkipList.Add(1);
        testSkipList.Add(2);
        testSkipList.Add(3);

        Assert.That(testSkipList[0], Is.EqualTo(1));
        Assert.That(testSkipList[1], Is.EqualTo(2));
        Assert.That(testSkipList[2], Is.EqualTo(3));

        Assert.That(testSkipList.Count, Is.EqualTo(3));

        testSkipList.RemoveAt(1);

        Assert.That(testSkipList.Count, Is.EqualTo(2));

        Assert.That(testSkipList[0], Is.EqualTo(1));
        Assert.That(testSkipList[1], Is.EqualTo(3));
    }

    [Test]
    public void RemoveAt_InvalidIndex_ShouldThrowsArgumentOutOfRangeException()
    {
        var testSkipList = new SkipList<int>();
        testSkipList.Add(1);
        testSkipList.Add(2);
        testSkipList.Add(3);

        Assert.That(testSkipList[0], Is.EqualTo(1));
        Assert.That(testSkipList[1], Is.EqualTo(2));
        Assert.That(testSkipList[2], Is.EqualTo(3));

        Assert.That(testSkipList.Count, Is.EqualTo(3));

        Assert.Throws<ArgumentOutOfRangeException>(() => testSkipList.RemoveAt(5));
    }

    [Test]
    public void Foreach_EmptyList_IterationCompletes()
    {
        var testSkipList = new SkipList<int>();
        int count = 0;

        foreach (var item in testSkipList)
        {
            count++;
        }

        Assert.That(count, Is.EqualTo(0));
    }

    [Test]
    public void Foreach_CompletedList_IterationsnTheCorrectOrder()
    {
        var testSkipList = new SkipList<int>();
        testSkipList.Add(1);
        testSkipList.Add(2);
        testSkipList.Add(3);

        var tmpList = new List<int>();

        foreach (var item in testSkipList)
        {
            tmpList.Add(item);
        }

        Assert.That(tmpList.Count, Is.EqualTo(3));

        Assert.That(tmpList[0], Is.EqualTo(1));
        Assert.That(tmpList[1], Is.EqualTo(2));
        Assert.That(tmpList[2], Is.EqualTo(3));
    }
}
