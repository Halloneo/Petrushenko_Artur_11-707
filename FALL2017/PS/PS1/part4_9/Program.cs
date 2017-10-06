using System;

namespace part4_9
{
    class Program
    {
        // Проверка, является ли число суммой пятых степеней его цифр
        public static bool CheckNumbers(int a)
        {
            int number = a;
            int sum = 0;
            while (a > 0)
            {
                int k = a % 10;
                sum += k * k * k * k * k;
                a /= 10;
            }
            return number == sum;
        }
        // Решение задачи №9 из 4 части
        // Решил Петрушенко Артур из группы 11-707

        static void Main(string[] args)
        {
            int min = 100000;
            int max = 999999;
            int sum = 0;
            for (int i = min; i <= max; i++)
                if (CheckNumbers(i))
                    sum += i;
            Console.WriteLine($"Сумма чисел равна {sum}");
        }
    }
}
