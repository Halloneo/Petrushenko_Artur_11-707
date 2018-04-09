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

            enrollees = enrollees.OrderBy(x => x.Year).ToList();

            foreach (var enrollee in enrollees)
            {
                Console.WriteLine($"{enrollee}");
            }
            Console.WriteLine();

            var answer = enrollees.GroupBy(applyier => applyier.Year, (year, count) => new { year, count = count.Count() })
                 .Where(group => group.count > enrollees.Count()/ enrollees.GroupBy(applier => applier.Year).Count());

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.count} {item.year}");
            }
        }
    }
}
