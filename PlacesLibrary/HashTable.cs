using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesLibrary
{
    public class HashTable
    {
        public LPoint[] table;
        public int Size;

        public HashTable(int size = 5)
        {
            Size = size;
            table = new LPoint[Size];
        }

        public bool Add(Place place)
        {
            if (place == null || string.IsNullOrEmpty(place.Name)) return false;

            LPoint point = new LPoint(place);
            int index = Math.Abs(LPoint.GetCustomHashCode(place.Name)) % Size;

            if (table[index] == null)
            {
                table[index] = point;
            }
            else
            {
                LPoint cur = table[index];
                if (string.Compare(cur.Value.Name, place.Name) == 0) return false;

                while (cur.Next != null)
                {
                    if (string.Compare(cur.Value.Name, place.Name) == 0) return false;
                    cur = cur.Next;
                }
                cur.Next = point;
            }
            return true;
        }

        public void Print()
        {
            if (table == null) { Console.WriteLine("Таблица пустая!"); return; }

            for (int i = 0; i < Size; i++)
            {
                if (table[i] == null)
                {
                    Console.WriteLine(i + " : [пусто]");
                }
                else
                {
                    Console.Write(i + " : ");
                    LPoint p = table[i];
                    while (p != null)
                    {
                        Console.Write(p.ToString() + " -> ");
                        p = p.Next;
                    }
                    Console.WriteLine("null");
                }
            }
        }

        public bool FindPoint(string name)
        {
            int code = Math.Abs(LPoint.GetCustomHashCode(name)) % Size;

            if (table[code] == null) return false;

            if (string.Compare(table[code].Value.Name, name) == 0)
                return true;

            LPoint lp = table[code];
            while (lp != null)
            {
                if (string.Compare(lp.Value.Name, name) == 0) return true;
                lp = lp.Next;
            }
            return false;
        }

        public Place DelPoint(string name)
        {
            int code = Math.Abs(LPoint.GetCustomHashCode(name)) % Size;

            if (table[code] == null) return null;

            LPoint lp = table[code];

            if (string.Compare(table[code].Value.Name, name) == 0)
            {
                table[code] = table[code].Next; 
                return lp.Value;
            }

            while (lp.Next != null && (string.Compare(lp.Next.Value.Name, name) != 0))
            {
                lp = lp.Next;
            }

            if (lp.Next != null)
            {
                Place removedValue = lp.Next.Value;
                lp.Next = lp.Next.Next; 
                return removedValue;
            }

            return null;
        }
    }
}
