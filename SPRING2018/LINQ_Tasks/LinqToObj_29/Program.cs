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
                .GroupBy(human => (human.Apartment - 1) / 36 + 1, 
                (entrance, inhabitant) => 
                new { entrance, inhabitant = inhabitant
                    .Where(man1 => man1.Debt == inhabitant
                    .Max(allMen => allMen.Debt)) })
                .OrderBy(data => data.entrance);

            foreach (var item in answer)
            {
                if (item.inhabitant.Any(data => data.Debt != 0))
                    Console.WriteLine($"{item.entrance}\t{item.inhabitant.First()}");

            }
        }
    }
}
