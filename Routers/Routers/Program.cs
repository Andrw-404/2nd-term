// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Routers;

if (args.Length != 2)
{
    Console.Error.WriteLine("Использование Routers <input_file> <output_file>");
    return 1;
}

try
{
    var newGraph = ReadFile.ReadFromFile(args[0]);
    var mst = PrimAlgorithm.FindMaximumSpanningTree(newGraph);
    var result = Output.TransformationMst(mst);
    File.WriteAllText(args[1], result);
    return 0;
}
catch (InvalidOperationException ex)
{
    Console.Error.WriteLine("Сеть не связна");
    return 1;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Ошибка: {ex.Message}");
    return 1;
}
