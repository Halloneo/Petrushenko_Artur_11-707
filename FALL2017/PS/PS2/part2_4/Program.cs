using System;

namespace part2_4
{
    class Program
    {
        // Петрушенко Артур решение задачи 4 из 2 части PS2
        public static double CalculatePI4Task(double E)
        {
            double k = 2;
            double item = 1;
            double sum = 1.0 / 6;
            while (Math.Abs(item) > E)
            {
                item = 1 / ((4 * k - 2) * (4 * k - 1));
                sum += item;
                k++;
            }
            return sum * 8 + 2 * Math.Log(2);
        }
        static void Main(string[] args)
        {
            double E = double.Parse(Console.ReadLine());

            double answer = CalculatePI4Task(E);

            Console.WriteLine($"{answer}");
            Console.ReadKey();
        }
    }
}
