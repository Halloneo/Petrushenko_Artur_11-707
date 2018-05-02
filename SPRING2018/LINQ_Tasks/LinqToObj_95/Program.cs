using System;
using System.Linq;

namespace LinqToObj_95
{
    class Program
    {
        private static void Main()
        {
            Generator.Generate(100);

            var customers = Generator.GetCustomers(100);

            var discounts = DiscountGenerator.GetDiscounts(100);

            var products = Generator.GetProducts(100);

            var purchases = Generator.GetPurchases(100);

            foreach (var discount in discounts)
            {
                Console.WriteLine(discount);
            }

            Console.WriteLine();

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();

            foreach (var purchase in purchases)
            {
                Console.WriteLine(purchase);
            }

            Console.WriteLine();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine();

            var answer = customers.Join(discounts, x => x.Code, x => x.Code, (x, y) => new
            {
                Code = x.Code,
                Street = x.Street,
                Year = x.Year,
                Name = y.Name,
                Discount = y.Percents
            }).Join(purchases, x => x.Code, x => x.Code, (x, y) => new
            {
                Code = x.Code,
                Street = x.Street,
                Year = x.Year,
                Name = x.Name,
                Discount = x.Discount,
                VendorCode = y.VendorCode
            }).Join(products, x => x.VendorCode, x => x.VendorCode, (x, y) => new
            {
                Code = x.Code,
                Street = x.Street,
                Year = x.Year,
                Name = x.Name,
                Discount = x.Discount,
                VendorCode = x.VendorCode,
                Price = y.Price
            }).GroupBy(x => new {x.VendorCode, x.Street}, (key, value) => new
            {
                key,
                value = value.Max(x => x.Discount)
            })
                .OrderBy(x => x.key.VendorCode)
                .ThenBy(x => x.key.Street);

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.key.VendorCode} {item.key.Street} {item.value}");
            }

        }
    }
}
