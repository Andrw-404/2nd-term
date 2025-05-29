// <copyright file="TestsForAllFunctions.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace FunctionalUtils.Tests;

public class TestsForAllFunctions
{
    private List<int> testNumbers;

    [SetUp]
    public void Setup()
    {
        this.testNumbers = new List<int> { 1, 2, 3, 4, 5 };
    }

    [Test]
    public void Map_CorrectInput_ShouldReturnCorrectList()
    {
        List<int> expectedList = new List<int> { 10, 20, 30, 40, 50 };
        var result = HaveMap.Map(this.testNumbers, x => x * 10);

        Assert.That(result, Is.EqualTo(expectedList));
    }

    [Test]
    public void Filter_CorrectInput_ShouldReturnCorrectList()
    {
        List<int> expectedList = new List<int> { 2, 4 };
        var result = HaveFilter.Filter(this.testNumbers, x => x % 2 == 0);

        Assert.That(result, Is.EqualTo(expectedList));
    }

    [Test]
    public void Fold_CorrectInput_ShouldReturnCorrectNumber()
    {
        var result = HaveFold.Fold(this.testNumbers, 1, (acc, el) => acc + el);

        Assert.That(result, Is.EqualTo(16));
    }

    [Test]
    public void Map_StringList_ShouldReturnCorrectList()
    {
        List<string> strings = new List<string> { "a", "bb", "ccc", "dddd" };
        List<int> expectedList = new List<int> { 1, 2, 3, 4 };
        var result = HaveMap.Map(strings, x => x.Length);

        Assert.That(result, Is.EqualTo(expectedList));
    }

    [Test]
    public void Filter_StringList_ShouldReturnCorrectList()
    {
        List<string> strings = new List<string> { "a", "bb", "ccc", "dddd" };
        List<string> expectedList = new List<string> { "ccc", "dddd" };
        var result = HaveFilter.Filter(strings, x => x.Length > 2);

        Assert.That(result, Is.EqualTo(expectedList));
    }

    [Test]
    public void Fold_StringList_ShouldReturnCorrectNumber()
    {
        List<string> strings = new List<string> { "Hello", "World" };
        string expected = "Hello-World";

        var result = HaveFold.Fold(strings, string.Empty, (accumulator, element) => accumulator + (accumulator == string.Empty ? string.Empty : "-") + $"{element}");

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Map_EmptyList_ShouldReturnCorrectList()
    {
        var result = HaveMap.Map(new List<int>(), x => x * 2);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Filter_EmptyList_ShouldReturnCorrectList()
    {
        var result = HaveFilter.Filter(new List<int>(), x => x % 2 == 1);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Fold_EmptyList_ShouldReturnCorrectNumber()
    {
        var result = HaveFold.Fold(new List<int>(), 0, (accumulator, number) => accumulator + number);

        Assert.That(result, Is.EqualTo(0));
    }
}