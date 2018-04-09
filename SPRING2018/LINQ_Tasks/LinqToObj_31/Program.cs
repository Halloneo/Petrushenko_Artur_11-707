using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObj_31
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
               new { entrance, inhabitant = inhabitant.OrderByDescending(item => item.Debt).Take(3) })
               .SelectMany(inhabitant => inhabitant.inhabitant)
               .OrderByDescending(inhabitant => inhabitant.Debt);

            foreach (var item in answer)
            {
                Console.WriteLine($"{(item.Apartment - 1) / 36 + 1}\t{item}");
            }
        }
    }
}
