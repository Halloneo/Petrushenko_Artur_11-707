using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObj_40
{
    class Program
    {
        static void Main(string[] args)
        {
            var petrolStations = Generator.GetPetrolStations(10);

            foreach (var item in petrolStations)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var answer = petrolStations.GroupBy(stations => stations.Street, (street, stations) =>
            new
            {
                street,
                stations = stations.GroupBy(fuel => fuel.Brand, (brand, count) =>
                new
                {
                    brand,
                    count = count.Count()
                })
            })
            .OrderBy(data => data.street);

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.street} {item.stations.Where(x => x.brand == 92).Count()} {item.stations.Where(x => x.brand == 95).Count()} {item.stations.Where(x => x.brand == 98).Count()}");
            }
        }
    }
}
