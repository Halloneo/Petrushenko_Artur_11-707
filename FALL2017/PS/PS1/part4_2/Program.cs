using System;

namespace part4_2
{
    class Program
    {
        // Проверка числа на простоту
        public static bool isPrime(int n)
        {
            if (n == 2)
                return true;
            if (n % 2 == 0)
                return false;
            int d = 3;
            while (n % d != 0 && d * d >= n)
                d += 2;
            return d * d > n;
        }
        // Решение задачи №2 из 4 части
        // Решил Петрушенко Артур из группы 11-707

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 2; i <= n; i++)
            {
                if (isPrime(i) && n % i == 0)
                    sum += i;
            }
            Console.WriteLine($"Сумма простых делителей числа равна {sum}");
        }
    }
}
