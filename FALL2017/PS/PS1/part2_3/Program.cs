using System;

namespace part2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Решение задачи №3 из 2 части
            // Решил Петрушенко Артур из группы 11-707

            Console.WriteLine("Введите первый элемент последовательности");
            int a1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второй элемент последовательности");
            int a2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество элементов");
            int n = int.Parse(Console.ReadLine());
            int b = a2 - a1;
            int sumOfNumbers = ((2 * a1 + b * (n - 1)) * n) / 2;
            Console.WriteLine($"Сумма равна {sumOfNumbers}");
        }
    }
}
