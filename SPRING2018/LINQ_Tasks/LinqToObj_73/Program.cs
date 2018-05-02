using System;
using System.Linq;

namespace LinqToObj_73
{
    class Program
    {
        static void Main()
        {
            var customers = CustomerGenerator.GetCustomers(100);

            var discounts = DiscountGenerator.GetDiscounts(100);

            foreach (var disc in discounts)
            {
                Console.WriteLine(disc);
            }
            Console.WriteLine();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine();

            var answer = customers.Join(discounts,
                    x => x.Code,
                    x => x.Code,
                    (x, y) => new { x.Street, x.Code, y.Percents, y.Name })
                .GroupBy(x => new { x.Name, x.Street })
                .Select(x => new { x.Key, Count = x.Count(y => y.Percents > 0) })
                .OrderBy(x => x.Key.Name)
                .ThenBy(x => x.Key.Street);

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.Key.Name} {item.Key.Street} {item.Count}");
            }
        }
    }
}
