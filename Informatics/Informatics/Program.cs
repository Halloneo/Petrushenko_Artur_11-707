using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatics
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            //var size = 1;
            //while (size < 127)
            //{
            //    size <<= 1;
            //}
            //Console.WriteLine(size);

            /*
            var tree = new SegmentTree(new int[] { 1, 2, 3, 4, 6, 7, 8, 9, 10 });

            var arr = new int[101];
            for (int i = 1; i <= 100; i++)
            {
                arr[i] = i;
            }
            for (int i = 1; i < 10; i++)
            {
                var ans = arr.Where(x => x % 10 == i);
                var count = 0;
                Console.Write($"{i})\t");
                foreach (var item in ans)
                {
                    Console.Write($"{item} ");
                    count++;
                }
                Console.WriteLine();
            }
            
            for (int i = 10; i < 21; i++)
            {
                var ans = arr.Where(x => x % 11 == i - 10);
                var count = 0;
                Console.Write($"{i})\t");
                foreach (var item in ans)
                {
                    if (item != 0)
                    {
                        Console.Write($"{item} ");
                        count++;
                    }
                }
                Console.WriteLine();
            }

            for (int i = 21; i < 23; i++)
            {
                var ans = arr.Where(x => (101 - x) % 11 == i - 20);
                var count = 0;

                Console.Write($"{i})\t");
                foreach (var item in ans)
                {
                    if (item != 0)
                    {
                        Console.Write($"{item} ");
                        count++;
                    }
                }
                Console.WriteLine();
            }

            //var ar = new SegmentTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            //Console.WriteLine(ar);
            */
            #endregion

            byte kek = 0;
            kek--;
            Console.WriteLine(kek);
            Console.WriteLine($"{(char)kek}" == "\xFF");
            Console.WriteLine("\xFF");
        }
    }
}
