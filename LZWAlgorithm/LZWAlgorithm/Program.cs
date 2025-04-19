// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using LZWAlgorithm;

if (args.Length != 2)
{
    Console.WriteLine("Использование LZWCompressor <файл> [-c | -u]");
    return;
}

string filePath = args[0];
string mode = args[1];

if (!File.Exists(filePath))
{
    Console.WriteLine("Файл не найден");
    return;
}

switch (mode)
{
    case "-c":
        string outputFile = Path.ChangeExtension(filePath, ".zipped");
        FileProcessor.CompressFile(filePath, outputFile);
        Console.WriteLine($"Файл сжат в {Path.GetFullPath(outputFile)}");
        break;

    case "-u":
        if (Path.GetExtension(filePath) != ".zipped")
        {
            Console.WriteLine("Файл должен иметь расширение .zipped");
            break;
        }

        string decompressedFile = Path.ChangeExtension(filePath, ".chgd");
        FileProcessor.DecompressFile(filePath, decompressedFile);
        Console.WriteLine($"Файл распакован и сохранен в {Path.GetFullPath(decompressedFile)}");
        break;

    default:
        Console.WriteLine("Используйте только -c (сжатие) и -u (распаковка)");
        break;
}
