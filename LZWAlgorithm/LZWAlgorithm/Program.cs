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
        string outputFile = filePath + ".zipped";
        CompressFile(filePath, outputFile);
        Console.WriteLine($"Файл сжат в {outputFile}");
        break;

    case "-u":
        if (!filePath.EndsWith(".zipped"))
        {
            Console.WriteLine("Файл должен иметь расширение .zipped");
            break;
        }

        string decompressedFile = filePath[..^".zipped".Length] + "chgd";
        DecompressFile(filePath, decompressedFile);
        Console.WriteLine($"Файл распакован и сохранен в {decompressedFile}");
        break;

    default:
        Console.WriteLine("Используйте только -c (сжатие) и -u (распаковка)");
        break;
}

static void CompressFile(string inputPath, string outputPath)
{
    byte[] inputBytes = File.ReadAllBytes(inputPath);
    int[] codes = LZW.Compress(inputBytes);

    using FileStream fs = new (outputPath, FileMode.Create);
    byte[] buffer = new byte[codes.Length * 4];
    Buffer.BlockCopy(codes, 0, buffer, 0, buffer.Length);
    fs.Write(buffer, 0, buffer.Length);

    FileInfo original = new (inputPath);
    FileInfo compressed = new (outputPath);
    double ratio = (double)original.Length / compressed.Length;
    Console.WriteLine($"Коэффициент сжатия: {ratio:F2}");
}

static void DecompressFile(string inputPath, string outputPath)
{
    byte[] compressedData = File.ReadAllBytes(inputPath);
    if (compressedData.Length % 4 != 0)
    {
        throw new InvalidDataException("Неверный формат сжатого файла");
    }

    int[] codes = new int[compressedData.Length / 4];
    Buffer.BlockCopy(compressedData, 0, codes, 0, compressedData.Length);

    byte[] outputBytes = LZW.Decompress(codes);
    File.WriteAllBytes(outputPath, outputBytes);
}