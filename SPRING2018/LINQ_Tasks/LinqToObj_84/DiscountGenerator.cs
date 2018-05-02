using System;
using System.Collections.Generic;
using System.IO;

namespace LinqToObj_84
{
    public class Discount
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Percents { get; set; }

        public Discount(string source)
        {
            var array = source.Split(' ');
            Code = int.Parse(array[0]);
            Name = array[1];
            Percents = int.Parse(array[2]);
        }

        public override string ToString()
        {
            return $"{Code}\t{Name}\t\t{Percents}";
        }
    }

    class DiscountGenerator
    {
        public static string[] Names { get; }

        static DiscountGenerator()
        {
            Names = new[]
            {
                "MVideo", "DNS", "Ulmart", "Technopoint", "Cifra", "MediaMarkt", "Svyaznoi"
            };
        }

        public static void Generate(int size)
        {
            var random = new Random();
            var directory = @"D:\Repository\Petrushenko_Artur\Petrushenko_Artur_11-707\SPRING2018\LINQ_Tasks\Data";

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqToObj_84C.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    sw.WriteLine($"{j + 1} {Names[random.Next(0, Names.Length)]} {random.Next(5, 51)}");
                }
            }
        }

        public static List<Discount> GetDiscounts(int size)
        {
            Generate(size);
            var directory = @"D:\Repository\Petrushenko_Artur\Petrushenko_Artur_11-707\SPRING2018\LINQ_Tasks\Data";

            var list = new List<string>();

            var discounts = new List<Discount>();

            using (StreamReader sr = new StreamReader($"{directory}\\LinqToObj_84C.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var discount in list)
            {
                discounts.Add(new Discount(discount));
            }

            return discounts;
        }
    }
}
