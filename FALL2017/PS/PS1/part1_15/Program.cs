using System;

namespace part1_15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Решение задачи №15 из 1 части
            // Решил Петрушенко Артур из группы 11-707
            
            Console.WriteLine("Введите номер билета");
            int number = int.Parse(Console.ReadLine());
            int oddSum = 0, evenSum = 0;
            for (int i = 0; number > 0; i++)
            {
                int lastNumber = number % 10;
                number /= 10;
                if (i % 2 == 0)
                    evenSum += lastNumber;
                else
                    oddSum += lastNumber;
            }
            if (oddSum == evenSum)
                Console.WriteLine("Является");
            else
                Console.WriteLine("Не является");
            
        }
    }
}
