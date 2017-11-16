using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part4_14
{
    class Program
    {
        static double Function(double x)
        {
            return Math.Sin(Math.Tan(x));
        }
        //
        public static double formulaOfLeftRectangles(double a, double b, int n)
        {
            double sum = 0;
            double del = (b - a) / n;

            for (int i = 0; i < n; i++)
                sum += Function(a + i * del);

            return del * sum;
        }
        //
        public static double formulaOfRightRectangles(double a, double b, int n)
        {
            double sum = 0;
            double del = (b - a) / n;

            for (int i = 1; i <= n; i++)
                sum += Function(a + i * del);

            return del * sum;
        }
        //
        public static double formulaOfTrapeze(double a, double b, int n)
        {
            double sum = 0;
            double del = (b - a) / (n);


            double previous = Function(a);
            double current;


            for (int i = 1; i <= n; i++)
            {
                current = Function(a + i * del);
                sum += (current + previous);
                previous = current;
            }

            return del * sum / 2;
        }
        //
        public static double formulaOfSimpson(double a, double b, int n)
        {
            double del = (b - a) / n;
            n /= 2;

            double sum1 = 0;
            for (int i = 1; i < n; i++)
            {
                sum1 += Function(a + 2 * i * del);
            }

            double sum2 = 0;
            for (int i = 1; i <= n; i++)
            {
                sum2 += Function(a + 2 * (i - 1) * del);
            }

            return del / 3 * ((Function(a) + 2 * sum1 + 4 * sum2 + Function(b)));
        }
        //
        public static double formulaOfMonteCarlo(double a, double b, int n)
        {
            double sum = 0;
            double del = (b - a) / n;
            Random random = new Random();

            for (int i = 0; i < n; i++)
                sum += Function(a + random.NextDouble() * (b - a));
            return sum * del;
        }
        //
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            int n = 10;

            var answerLeftRect = formulaOfLeftRectangles(0.0, 1.5, n);
            var answerRightRect = formulaOfRightRectangles(0.0, 1.5, n);
            var answerTrapeze = formulaOfTrapeze(0.0, 1.5, n);
            var answerSimpson = formulaOfSimpson(0.0, 1.5, n);
            var answerMonteCarlo = formulaOfMonteCarlo(0.0, 1.5, n);
        }
    }
}
