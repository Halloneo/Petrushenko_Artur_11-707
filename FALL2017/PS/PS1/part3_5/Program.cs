using System;

namespace part3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Решение задачи №5 из 3 части
            // Решил Петрушенко Артур из группы 11-707

            Console.WriteLine("Введите X первой вершины треугольника");
            double x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите Y первой вершины треугольника");
            double y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите X второй вершины треугольника");
            double x2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите Y второй вершины треугольника");
            double y2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите X третьей вершины треугольника");
            double x3 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите Y третьей вершины треугольника");
            double y3 = double.Parse(Console.ReadLine());

            double a = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            double b = Math.Sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3));
            double c = Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2));

            double p = (a + b + c) / 2;

            double triangleSquare = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            int count = 0;

            Console.WriteLine("Введите количество проверяемых точек");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите X {i + 1} точки");
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine($"Введите Y {i + 1} точки");
                double y = double.Parse(Console.ReadLine());

                double distanceToA = Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));
                double distanceToB = Math.Sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));
                double distanceToC = Math.Sqrt((x - x3) * (x - x3) + (y - y3) * (y - y3));

                double perim1 = (distanceToA + distanceToB + a) / 2;
                double perim2 = (distanceToA + distanceToC + b) / 2;
                double perim3 = (distanceToC + distanceToB + c) / 2;

                double square1 = Math.Sqrt(perim1 * (perim1 - distanceToA) * (perim1 - distanceToB) * (perim1 - a));
                double square2 = Math.Sqrt(perim2 * (perim2 - distanceToA) * (perim2 - distanceToC) * (perim2 - b));
                double square3 = Math.Sqrt(perim3 * (perim3 - distanceToC) * (perim3 - distanceToB) * (perim3 - c));

                if (Math.Abs(square1 + square2 + square3 - triangleSquare) < 1e-5)
                    count++;
            }
            Console.WriteLine($"Количество точек, лежащих внутри треугольника равно {count}");
        }
    }
}
