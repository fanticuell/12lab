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
            Random rnd = new Random();

            Place[] places = new Place[5];

            for (int i = 0; i < places.Length; i++)
            {
                int type = rnd.Next(5);

                switch (type)
                {
                    case 0:
                        places[i] = new Place();
                        break;
                    case 1:
                        places[i] = new Region();
                        break;
                    case 2:
                        places[i] = new City();
                        break;
                    case 3:
                        places[i] = new Megapolis();
                        break;
                    case 4:
                        places[i] = new Address();
                        break;
                }

                places[i].RandomInit();
            }

            Console.WriteLine("=== Обычный вызов ===");
            foreach (Place p in places)
            {
                p.Show();
                Console.WriteLine();
            }

            Array.Sort(places);

            Console.WriteLine("\n=== После сортировки по Name ===");
            foreach (var p in places)
            {
                p.Show();
                Console.WriteLine();
            }

            Array.Sort(places, new PopulationComparer());

            Console.WriteLine("\n=== Сортировка по населению ===");
            foreach (var p in places)
            {
                p.Show();
                Console.WriteLine();
            }

            Place target = new Place("Место1");

            int index = Array.BinarySearch(places, target);

            if (index >= 0)
            {
                Console.WriteLine("\nНайден элемент:");
                places[index].Show();
            }
            else
            {
                Console.WriteLine("\nЭлемент не найден");
            }

            IInit[] arr = new IInit[5];

            arr[0] = new Place();
            arr[1] = new City();
            arr[2] = new Megapolis();
            arr[3] = new Address();
            arr[4] = new RandomClass();

            Console.WriteLine("\n=== RandomInit для IInit ===");

            foreach (var obj in arr)
            {
                obj.RandomInit();

                if (obj is Place p)
                    p.Show();
                else if (obj is RandomClass rn)
                    rn.Show();
            }

            Place original = new Place();
            original.RandomInit();
            original.Addr = new Address();
            original.Addr.RandomInit();

            Place clone = (Place)original.Clone();
            Place shallow = original.ShallowCopy();

            Console.WriteLine("\n=== Клонирование ===");

            original.Addr.Street = "Ленина2";

            Console.WriteLine("\nПосле изменения оригинала:");

            original.Addr.Show();
            shallow.Addr.Show();
            clone.Addr.Show();

            //Console.Write("\nВведите центр области: ");
            //string center = Console.ReadLine();

            //Console.Write("Введите минимальное население: ");
            //int minPop = int.Parse(Console.ReadLine());

            //Console.Write("Введите улицу: ");
            //string street = Console.ReadLine();

            //CitiesByRegion(places, center);
            //MegapolisByPopulation(places, minPop);
            //CountAddressesByStreet(places, street);
        }

        static void CitiesByRegion(Place[] places, string regionCenter)
        {
            Console.WriteLine($"\nГорода области с центром: {regionCenter}");

            foreach (Place p in places)
            {
                if (p is City city)
                {
                    if (city.RegionCenter == regionCenter)
                    {
                        Console.WriteLine(city.Name);
                    }
                }
            }
        }

        static void MegapolisByPopulation(Place[] places, int minPopulation)
        {
            Console.WriteLine($"\nМегаполисы с населением больше {minPopulation}:");

            foreach (Place p in places)
            {
                if (p is Megapolis mega)
                {
                    if (mega.Population > minPopulation)
                    {
                        mega.Show();
                        Console.WriteLine();
                    }
                }
            }
        }

        static void CountAddressesByStreet(Place[] places, string street)
        {
            int count = 0;

            foreach (Place p in places)
            {
                if (p is Address addr)
                {
                    if (addr.Street == street)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine($"\nКоличество адресов на улице {street}: {count}");
        }
    }
}
