using System;

namespace part3_3
{
    class Program
    {
        // Петрушенко Артур решение задачи 3 из 3 части PS2
        static public double CalculateGaussLezhandrTask3(double E)
        {
            double a = 1.0;
            double b = 1.0 / Math.Sqrt(2);
            double t = 1.0 / 4.0;
            double p = 1.0;
            double temp = 0;
            while (Math.Abs(Math.PI - temp) > E)
            {
                double b0 = b, a0 = a;
                
                b = Math.Sqrt(a * b0);
                a = (a + b0) / 2;
                t = t - p * (a0 - a) * (a0 - a);
                p *= 2;
                temp = (a + b) * (a + b) / (4 * t);
            }

            return temp;
        }
        static void Main(string[] args)
        {
            double E = double.Parse(Console.ReadLine());

            double answer = CalculateGaussLezhandrTask3(E);

            Console.WriteLine($"{answer}");
            Console.ReadKey();
        }
    }
}