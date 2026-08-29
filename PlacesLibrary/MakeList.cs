using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesLibrary
{
    public class MakeList
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public int Count { get; private set; }

        public void AddLast(Place data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
            Count++;
        }

        public void PrintList(string message)
        {
            Console.WriteLine($"\n--- {message} ---");
            if (Head == null)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            Node current = Head;
            int index = 1;
            while (current != null)
            {
                Console.Write($"[{index}] ");
                current.Data.Show();
                current = current.Next;
                index++;
            }
        }

        public void RemoveEvenPositions()
        {
            if (Head == null) return;

            Node current = Head;
            int currentPosition = 1;

            while (current != null)
            {
                Node nextNode = current.Next;

                if (currentPosition % 2 == 0)
                {
                    if (current == Tail)
                    {
                        Tail = current.Prev;
                    }

                    if (current.Prev != null) current.Prev.Next = current.Next;
                    if (current.Next != null) current.Next.Prev = current.Prev;

                    current.Next = null;
                    current.Prev = null;

                    Count--;
                }

                current = nextNode;
                currentPosition++;
            }
        }

        public void Clear()
        {
            Node current = Head;
            while (current != null)
            {
                Node next = current.Next;
                current.Next = null;
                current.Prev = null;
                current.Data = null;

                current = next;
            }
            Head = null;
            Tail = null;
            Count = 0;
        }
    }
}
