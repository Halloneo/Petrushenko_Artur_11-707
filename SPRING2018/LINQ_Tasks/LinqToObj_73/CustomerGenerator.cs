using System;
using System.Collections.Generic;
using System.IO;

namespace LinqToObj_73
{
    public class Customer
    {
        public int Year { get; set; }
        public int Code { get; set; }
        public string Street { get; set; }

        public Customer(string source)
        {
            var array = source.Split(' ');
            Year = int.Parse(array[0]);
            Code = int.Parse(array[1]);
            Street = array[2];
        }

        public override string ToString()
        {
            return $"{Year}\t{Code}\t{Street}";
        }
    }

    public class CustomerGenerator
    {
        public static string[] Streets { get; }

        static CustomerGenerator()
        {
            Streets = new[]
            {
                "Adoratskogo", "Gavrilova", "Dekabristov", "Korolenko", "Yamasheva", "Tolstogo", "Absalyamova"
            };
        }

        public static void Generate(int size)
        {
            var random = new Random();
            var directory = @"D:\Repository\Petrushenko_Artur\Petrushenko_Artur_11-707\SPRING2018\LINQ_Tasks\Data";

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqToObj_73_Customer.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    sw.WriteLine($"{random.Next(1999, 2018)} {j + 1} {Streets[random.Next(0, Streets.Length)]}");
                }
            }
        }

        public static List<Customer> GetCustomers(int size)
        {
            Generate(size);
            var directory = @"D:\Repository\Petrushenko_Artur\Petrushenko_Artur_11-707\SPRING2018\LINQ_Tasks\Data";

            var list = new List<string>();

            var customers = new List<Customer>();

            using (StreamReader sr = new StreamReader($"{directory}\\LinqToObj_73_Customer.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var customer in list)
            {
                customers.Add(new Customer(customer));
            }

            return customers;
        }
    }
}
