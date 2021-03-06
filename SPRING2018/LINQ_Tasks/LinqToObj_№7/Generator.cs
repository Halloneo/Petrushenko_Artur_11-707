﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObj__7
{
    public class FitnesClient
    {
        public int Code { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Duration { get; set; }

        public FitnesClient(string source)
        {
            var tmp = source.Split(' ');
            var array = Array.ConvertAll(tmp, Convert.ToInt32);
            Code = array[0];
            Year = array[1];
            Month = array[2];
            Duration = array[3];
        }

        public override string ToString()
        {
            return $"{Code}\t{Year}\t{Month}\t{Duration}";
        }
    }

    public class Generator
    {
        public static int[] Years { get; }

        public static int[] Codes { get; }

        public static int[] Moths { get; }

        static Generator()
        {
            Years = new int[20];
            for (int i = 0, year = 1998; i < Years.Length; i++, year++)
            {
                Years[i] = year;
            }

            Codes = new int[100];
            for (int i = 0, code = 1; i < Codes.Length; i++, code++)
            {
                Codes[i] = code;
            }

            Moths = new int[12];
            for (int i = 0; i < Moths.Length; i++)
            {
                Moths[i] = i + 1;
            }
        }

        public static void Generate(int size)
        {
            var random = new Random();
            var directory = @"C:\Users\petru\Desktop\Data";

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqToObj_7.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    sw.WriteLine($"{Codes[random.Next(0, Codes.Length)]} {Years[random.Next(0, Years.Length)]} {Moths[random.Next(0, Moths.Length)]} {random.Next(1, 24)}");
                }
            }
        }

        public static List<FitnesClient> GetCLients(int size)
        {
            Generate(size);
            var directory = @"C:\Users\petru\Desktop\Data";

            var list = new List<string>();
            var clients = new List<FitnesClient>();
            using (StreamReader sr = new StreamReader($"{directory}\\LinqToObj_7.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var client in list)
            {
                clients.Add(new FitnesClient(client));
            }

            return clients;
        }
    }
}
