using System;
using System.Collections;
using System.Collections.Generic;

namespace Informatics
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class SinglyLinkedList<T> : IEnumerable
    {
        public int Count { get; private set; }

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public void Add(T item)
        {
            Node<T> node = new Node<T>() { Data = item };

            if (Head == null)
            {
                Head = Tail = node;
            }

            else
            {
                Tail.Next = node;
                Tail = node;
            }

            Count++;
        }

        public bool Remove(T item)
        {
            Node<T> previous = null;
            Node<T> current = Head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;
                        if (Head == null)
                            Tail = null;
                    }

                    Count--;

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException();

                var item = Head;

                for (int i = 0; i < index; i++)
                    if (item.Next == null)
                        throw new IndexOutOfRangeException();
                    else
                        item = item.Next;

                return item.Data;
            }
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> current = Head;

            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}