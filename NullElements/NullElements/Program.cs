// <copyright file="Program.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

using NullElements;

var intList = new MyList<int>();
intList.Add(0);
intList.Add(0);
intList.Add(0);
intList.Add(0);

Console.WriteLine(Counter.CountNulls(intList, new IntNullChecker()));
