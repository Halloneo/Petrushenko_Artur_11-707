using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObj_18
{
    class Program
    {
        static void Main(string[] args)
        {
            var enrollees = Generator.GetEnrollees(10);

            foreach (var enrollee in enrollees)
            {
                Console.WriteLine($"{enrollee}");
            }
            Console.WriteLine();

            var answer = enrollees
                .GroupBy(applyier => applyier.Year, (year, count) => 
                new { year, count = count.Count() })
                .Where(group => group.count > enrollees.Count()/ enrollees.GroupBy(applier => applier.Year)
                .Count())
                .OrderByDescending(data => data.count)
                .ThenBy(data => data.year);

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.count} {item.year}");
            }
        }
    }
}
