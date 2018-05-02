using System;
using System.Linq;

namespace LinqToObj_84
{
    class Program
    {
        static void Main()
        {
            Generator.Generate(100);

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

            var answer = purchases.Join(products, x => x.VendorCode, x => x.VendorCode,
                    (x, y) => new
                    {
                        Name = x.Name,
                        VendorCode = x.VendorCode,
                        Price = y.Price,
                        Code = x.Code
                    })
                .Join(discounts, x => x.Code, x => x.Code, (x, y) => new
                {
                    Name = x.Name,
                    VendorCode = x.VendorCode,
                    Price = x.Price,
                    Code = x.Code,
                    Discount = y.Percents
                })
                .GroupBy(x => new {x.Name, x.VendorCode},
                    (key, count) => new
                    {
                        Key = key,
                        Count = count.Count(),
                        Sum = count.Sum(x => x.Price / x.Discount * 100)
                    })
                .OrderBy(x => x.Key.Name)
                .ThenBy(x => x.Key.VendorCode);

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.Key.Name} {item.Key.VendorCode} {item.Count} {item.Sum}");
            }
        }
    }
}
