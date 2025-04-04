// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Routers;

Console.WriteLine("\nВведите имя(с расширением) исходного файла");
var inputPath = Console.ReadLine();
if (inputPath == null)
{
    throw new ArgumentNullException();
}

Console.WriteLine("\nВведите имя(с расширением) выходного файла");
var outputPath = Console.ReadLine();
if (outputPath == null)
{
    throw new ArgumentNullException();
}

try
{
    var newGraph = ReadFile.ReadFromFile(inputPath);
    var mst = PrimAlgorithm.FindMaximumSpanningTree(newGraph);
    var result = Output.TransformationMst(mst);
    File.WriteAllText(outputPath, result);
    Console.WriteLine("\nУспешно\n");
    return 0;
}
catch (InvalidOperationException ex) when (ex.Message.Contains("несвязный"))
{
    Console.Error.WriteLine("\nСеть не связна\n");
    return 1;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Ошибка: {ex.Message}");
    return 1;
}
