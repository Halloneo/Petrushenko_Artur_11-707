using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObj__7
{
    class Program
    {
        static void Main(string[] args)
        {
            var clients = Generator.GetCLients(500);

            var code = new Random().Next(0, 101);

            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
            Console.WriteLine();

            var answer = clients
                .GroupBy(client => new { client.Year, client.Code },
                (currClient, month) => 
                new {
                        currClient,
                        month = month.First(client => client.Duration == month.Max(client1 => client1.Duration))
                    })
                .Where(client => client.currClient.Code == code)
                .OrderByDescending(data => data.currClient.Year);

            if (answer.Any())
            {
                foreach (var item in answer)
                {
                    Console.WriteLine($"{item.month.Year} {item.month.Month}");
                }
            }
            else
            {
                Console.WriteLine("Нет данных");
            }
        }
    }
}
