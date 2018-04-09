using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObj_29
{
    class Program
    {
        static void Main(string[] args)
        {
            var inhabitants = Generator.GetInhabitants();

            foreach (var inhabitant in inhabitants)
            {
                Console.WriteLine(inhabitant);
            }
            Console.WriteLine();

            var answer = inhabitants
                .GroupBy(human => (human.Apartment - 1) / 36 + 1, (entrance, inhabitant) =>
               new { entrance, inhabitant = inhabitant.Where(man1 => man1.Debt == inhabitant.Max(allMen => allMen.Debt)) });

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.entrance}\t{item.inhabitant.First()}");
            }
        }
    }
}
