// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using FunctionalUtils;

var numbers = new List<int> { 1, 2, 3, 4, 5 };

var res1 = HaveMap.Map(numbers, x => x * 2);
Console.WriteLine($"Map: {string.Join(", ", res1)}");

var res2 = HaveFilter.Filter(numbers, x => x % 2 == 1);
Console.WriteLine($"Filter: {string.Join(", ", res2)}");

var res3 = HaveFold.Fold(numbers, 1, (acc, elem) => acc * elem);
Console.WriteLine($"Fold: {res3}");