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
            //var size = 1;
            //while (size < 127)
            //{
            //    size <<= 1;
            //}
            //Console.WriteLine(size);


            //var kek = new SegmentTree(new int[] { 1, 2, 3, 4, 6, 7, 8, 9, 10 });

            //var arr = new int[101];
            //for (int i = 1; i <= 100; i++)
            //{
            //    arr[i] = i;
            //}
            //var ans = arr.Where(x => x % 11 == 14 - 10);
            //var count = 0;
            //foreach (var item in ans)
            //{
            //    Console.WriteLine(item);
            //    count++;
            //}
            //Console.WriteLine(count);

            var kek = new SegmentTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            Console.WriteLine(kek);


        }
    }
}
