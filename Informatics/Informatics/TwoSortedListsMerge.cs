using System;

namespace Informatics
{
    class TwoSortedListsMerge<T> where T : IComparable
    {
        public static SinglyLinkedList<T> Merge(SinglyLinkedList<T> First, SinglyLinkedList<T> Second)
        {
            var newList = new SinglyLinkedList<T>();
            var firstElem = First.Head;
            var secondElem = Second.Head;
            while (firstElem != null && secondElem != null)
            {
                if (firstElem.Data.CompareTo(secondElem.Data) < 0)
                {
                    newList.Add(firstElem.Data);
                    firstElem = firstElem.Next;
                }
                else
                {
                    newList.Add(secondElem.Data);
                    secondElem = secondElem.Next;
                }
            }
            if (firstElem != null)
            {
                while (firstElem != null)
                {
                    newList.Add(firstElem.Data);
                    firstElem = firstElem.Next;
                }
            }
            else if (secondElem != null)
            {
                while (secondElem != null)
                {
                    newList.Add(secondElem.Data);
                    secondElem = secondElem.Next;
                }
            }
            return newList;
        }
    }
}
