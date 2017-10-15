using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1_14
{
    class Program
    {
        // Петрушенко Артур Решение задачи 14 из 1 части PS2
        public static double CalculateSum14Task(double E, double x, out int iterations)
        {
            double sum = 1;
            int k = 1;
            double item = 1;
            while (Math.Abs(item) > E)
            {
                item *= -x * (k + 1) / k;
                sum += item;
                k++;
            }
            iterations = k - 1;
            return sum;
        }
        static void Main(string[] args)
        {
            double E = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
           
            double answer = CalculateSum14Task(E, x, out int iterations);

            Console.WriteLine($"{answer} {iterations}");
            Console.ReadKey();
        }
    }
}
