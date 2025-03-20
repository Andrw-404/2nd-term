using System;
using BWT;

if (!Tests.RunTest())
{
    return 1;
}

while (true)
{
    Console.WriteLine("Выберите преобразование:");
    Console.WriteLine("1) Прямое преобразование");
    Console.WriteLine("2) Обратное преобразование");
    Console.WriteLine("3) Выход");
    Console.Write("Выбор: ");

    string choice = Console.ReadLine()!;
    switch (choice)
    {
        case "1":
            Console.Write("\nВведите строку: ");
            string frontUserString = Console.ReadLine()!;
            var (frontBWTResult, frontBWTIndex) = BWTAlgorithm.FrontBWT(frontUserString);
            Console.WriteLine($"Преобразованная строка: {frontBWTResult}; Индекс: {frontBWTIndex}\n");
            break;
        case "2":
            Console.Write("Введите преобразованную строку: ");
            string inversetUserString = Console.ReadLine()!;
            Console.Write("Введите индекс: ");
            int indexOfUserString = int.Parse(Console.ReadLine()!);
            string originalString = BWTAlgorithm.InverseBWT(inversetUserString, indexOfUserString);
            Console.WriteLine($"Исходная строка: {originalString}\n");
            break;
        case "3":
            Console.WriteLine("Выход...");
            return 0;
        default:
            Console.WriteLine("Неверный ввод\n");
            break;
    }
}