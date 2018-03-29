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
            var list1 = new SinglyLinkedList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(5);
            list1.Add(8);
            list1.Add(10);
            list1.Add(17);
            list1.Add(19);
            list1.Add(25);
            list1.Add(45);
            var list2 = new SinglyLinkedList<int>();
            list2.Add(4);
            list2.Add(6);
            list2.Add(7);
            list2.Add(9);
            list2.Add(11);
            list2.Add(12);
            list2.Add(20);
            list2.Add(21);
            list2.Add(23);
            list2.Add(27);
            list2.Add(29);
            var newList = TwoSortedListsMerge<int>.Merge(list1, list2);
            foreach (var item in newList)
            {
                Console.Write($"{item.Data} ");
            }
        }
    }
}
