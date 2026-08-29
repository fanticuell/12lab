using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PlacesLibrary;

namespace _10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания");
            string zadanie = Console.ReadLine();
            Console.WriteLine();
            if (zadanie == "1")
            {
                MakeList list = new MakeList();
                list.AddLast(new Place("Центральный Парк"));
                list.AddLast(new Region("Московская область", "Center"));
                list.AddLast(new City("Казань", "Center2", 1234321));
                list.AddLast(new Megapolis("Токио", "Center3", 666666, true));
                list.AddLast(new Place("Секретное место"));
                list.AddLast(new City("Пермь", "Center4", 1020400));

                list.PrintList("Исходный список (Пункт 2)");

                list.RemoveEvenPositions();
                Console.WriteLine("\n[Система]: Произведено удаление элементов на четных позициях.");

                list.PrintList("Список после удаления четных элементов (Пункт 4)");

                list.Clear();

                list.PrintList("Проверка списка после очистки memory");
            }
            else if (zadanie == "2")
            {

            }
            else if (zadanie == "3")
            {

            }
            else if (zadanie == "4")
            {

            }
        }

    }
}
