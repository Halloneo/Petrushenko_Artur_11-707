using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1_16
{
    class Program
    {
        // Петрушенко Артур Решение задачи 16 из 1 части PS2
        public static double CalculateSum16Task(double E, out int iterations)
        {
            double item = 1;
            double n = 1;
            double sum = 1;
            while (Math.Abs(item) > E)
            {
                item *= -1 * (2 * n - 1) * (2 * n - 1) / ((2 * n + 1) * (2 * n + 1));
                sum += item;
                n++;
            }
            iterations = (int)n;
            return sum;
        }
        static void Main(string[] args)
        {
            double E = double.Parse(Console.ReadLine());
          
            double answer = CalculateSum16Task(E, out int iterations);

            Console.WriteLine($"{answer} {iterations}");
            Console.ReadKey();
        }
    }
}