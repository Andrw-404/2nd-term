// <copyright file="Program.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
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

if (string.IsNullOrWhiteSpace(fileName))
{
    Console.WriteLine("Не указано имя файла");
    return;
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