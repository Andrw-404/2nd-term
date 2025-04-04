// <copyright file="FIleProcessor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZWAlgorithm
{
    /// <summary>
    /// Provides methods for compressing and decompressing files using the LZW algorithm.
    /// </summary>
    public static class FileProcessor
    {
        /// <summary>
        /// The method that causes file compression.
        /// </summary>
        /// <param name="inputPath">The path where the file is stored for compression.</param>
        /// <param name="outputPath">The path where the compressed file is stored.</param>
        public static void CompressFile(string inputPath, string outputPath)
        {
            byte[] inputBytes = File.ReadAllBytes(inputPath);
            int[] codes = LZW.Compress(inputBytes);

            using FileStream fs = new (outputPath, FileMode.Create);
            byte[] buffer = new byte[codes.Length * sizeof(int)];
            Buffer.BlockCopy(codes, 0, buffer, 0, buffer.Length);
            fs.Write(buffer, 0, buffer.Length);

            FileInfo original = new (inputPath);
            FileInfo compressed = new (outputPath);

            if (original.Length == 0)
            {
                Console.WriteLine("Исходный файл пуст");
            }
            else if (compressed.Length == 0)
            {
                Console.WriteLine("Сжатый файл пуст");
            }
            else
            {
                double ratio = (double)original.Length / compressed.Length;
                Console.WriteLine($"Коэффициент сжатия: {ratio:F2}");
            }
        }

        /// <summary>
        /// The method that causes the file to be decompressed.
        /// </summary>
        /// <param name="inputPath">The path where the compressed file is stored.</param>
        /// <param name="outputPath">The path where the already uncompressed file is stored.</param>
        /// <exception cref="InvalidDataException">
        /// It is thrown if the size of the compressed file is not a multiple of the size of the type "int", which indicates a corrupted file format.
        /// </exception>
        public static void DecompressFile(string inputPath, string outputPath)
        {
            byte[] compressedData = File.ReadAllBytes(inputPath);
            if (compressedData.Length % sizeof(int) != 0)
            {
                throw new InvalidDataException("Неверный формат сжатого файла");
            }

            int[] codes = new int[compressedData.Length / sizeof(int)];
            Buffer.BlockCopy(compressedData, 0, codes, 0, compressedData.Length);

            byte[] outputBytes = LZW.Decompress(codes);
            File.WriteAllBytes(outputPath, outputBytes);
        }
    }
}
