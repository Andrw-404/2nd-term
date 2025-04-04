// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ParsingTree;

string? fileName;
if (args.Length == 0)
{
    Console.Write("\nВведите название файла с его расширением: ");
    fileName = Console.ReadLine();
}
else
{
    fileName = args[0];
}

try
{
    string input = File.ReadAllText(fileName);
    Node root = new Parser().Parse(input);

    root.Print();
    Console.WriteLine($"\nResult: {root.ValueOrExpression()}\n");
}
catch (Exception exception)
{
    Console.WriteLine($"{exception.Message}");
}