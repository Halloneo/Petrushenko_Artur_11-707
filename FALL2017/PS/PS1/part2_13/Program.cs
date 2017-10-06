using System;

namespace part2_13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Решение задачи №13 из 2 части
            // Решил Петрушенко Артур из группы 11-707

            Console.WriteLine("Введите число");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите порядок системы счисления");
            int k = int.Parse(Console.ReadLine());
            int sumOfNumbers = 0;
            while (number > 0)
            {
                sumOfNumbers += number % k;
                number /= k;
            }
            Console.WriteLine($"Сумма цифр равна {sumOfNumbers}");
        }
    }
}
