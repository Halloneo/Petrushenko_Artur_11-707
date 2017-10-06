using System;

namespace part3_15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Решение задачи №15 из 3 части
            // Решил Петрушенко Артур из группы 11-707

            Console.WriteLine("Введите k");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество чисел n");
            int n = int.Parse(Console.ReadLine());
            int chainLength = 0;
            int temporaryNumber = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1} число");
                int a = int.Parse(Console.ReadLine());
                if (a == k)
                    temporaryNumber++;
                if (temporaryNumber > chainLength && (a != k || i == n - 1))
                {
                    chainLength = temporaryNumber;
                    temporaryNumber = 0;
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Максимальная длина цепочки равна {chainLength}");
        }
    }
}
