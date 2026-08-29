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
                Console.WriteLine("\nПроизведено удаление элементов на четных позициях.");

                list.PrintList("Список после удаления четных элементов (Пункт 4)");

                list.Clear();

                list.PrintList("Проверка списка после очистки memory");
            }
            else if (zadanie == "2")
            {
                List<Place> initialList = new List<Place>
                {
                    new Place("Центральный Парк"),
                    new City("Казань", "Center1", 1234321),
                    new Megapolis("Токио", "Center2", 666666, true),
                    new Place("Секретное место"),
                    new City("Пермь", "Center3", 1020400),
                    new Region("Московская область", "Center4"),
                    new City("Новгород", "Center5", 300000)
                };

                BinaryTree tree = new BinaryTree();

                tree.BuildIdealBalanced(initialList);

                tree.PrintTree("Идеально сбалансированное дерево (Пункт 2)");

                double avgPopulation = tree.GetAveragePopulation();
                Console.WriteLine($"\n[Результат Пункта 3]: Среднее население городов в дереве = {avgPopulation:F2} чел.");

                tree.ConvertToSearchTree();
                Console.WriteLine("\nДерево преобразовано в дерево поиска (сортировка по алфавиту имен).");

                tree.PrintTree("Дерево поиска (Пункт 5)");

                tree.Clear();

                tree.PrintTree("Проверка дерева после очистки");
            }
            else if (zadanie == "3")
            {
                Place[] arr = new Place[]
                {
                    new Place("Центральный Парк"),
                    new City("Казань", "Center1", 1234321),
                    new Megapolis("Токио", "Center2", 666666, true),
                    new Place("Секретное место"),
                    new City("Пермь", "Center3", 1020400),
                    new Region("Московская область", "Center4"),
                    new City("Новгород", "Center5", 300000)
                };

                HashTable ht = new HashTable(5);

                foreach (Place p in arr)
                {
                    ht.Add(p);
                }

                Console.WriteLine("=== Исходная хеш-таблица (Пункт 1) ===");
                ht.Print();

                string searchKey = "Пермь";
                Console.WriteLine($"\n[Пункт 2]: Поиск элемента '{searchKey}'...");
                if (ht.FindPoint(searchKey))
                    Console.WriteLine("-> Результат: Элемент найден!");
                else
                    Console.WriteLine("-> Результат: Элемент НЕ найден.");

                Console.WriteLine($"\n[Пункт 3]: Удаление элемента '{searchKey}'...");
                Place deleted = ht.DelPoint(searchKey);
                if (deleted != null)
                    Console.WriteLine($"-> Успешно удален объект: {deleted.Name}");
                else
                    Console.WriteLine("-> Не удалось найти элемент для удаления.");

                Console.WriteLine("\n=== Хеш-таблица после удаления (Пункт 3) ===");
                ht.Print();

                Console.WriteLine($"\n[Пункт 4]: Повторный поиск элемента '{searchKey}'...");
                if (ht.FindPoint(searchKey))
                    Console.WriteLine("-> Результат: Элемент всё ещё в таблице (ошибка).");
                else
                    Console.WriteLine("-> Результат: Элемент отсутствует (успешно удален).");

                Console.WriteLine("\n[Пункт 5]: Демонстрация добавления в уже занятые ячейки (коллизия)...");
                ht.Add(new City("Омск", "Center3", 1100000));
                ht.Add(new Place("Новое Место"));

                Console.WriteLine("\n=== Финальный вид таблицы со вложенными цепочками ===");
                ht.Print();
            }
            else if (zadanie == "4")
            {
                Console.WriteLine("=== Демонстрация создания и наполнения коллекции ===");

                MyCollection coll1 = new MyCollection(5);

                coll1.Add(new Place("Парк Горького"));
                coll1.Add(new City("Казань", "Center1", 1234321));

                Place[] additionalItems = { new Megapolis("Токио", "Center2", 666666, true), new City("Пермь", "Cnter3", 1020400) };
                coll1.AddRange(additionalItems);

                Console.WriteLine("\nВывод коллекции через цикл foreach:");
                foreach (Place p in coll1)
                {
                    p.Show();
                }

                Console.WriteLine($"\nТекущее количество элементов: {coll1.Count} (Ёмкость: {coll1.Capacity})");

                try
                {
                    Console.WriteLine("\nПопытка добавить 2 элемента при оставшемся лимите 1");
                    coll1.Add(new Place("Место 5"));
                    coll1.Add(new Place("Место 6 (Лишнее)"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка! {ex.Message}");
                }

                Console.WriteLine("\n=== Тестирование поиска ===");
                Place dummyForSearch = new Place("Парк Горького");
                Place found = coll1.Find(dummyForSearch);
                Console.WriteLine(found != null ? $"Найдено: {found.Name}" : "Не найдено");

                Console.WriteLine("\n=== Тестирование удаления ===");
                coll1.Remove(dummyForSearch);
                Console.WriteLine("После удаления 'Парк Горького' список:");
                foreach (Place p in coll1) Console.WriteLine($" - {p.Name}");

                Console.WriteLine("\n=== Клонирование и поверхностное копирование ===");
                MyCollection deepClone = coll1.DeepClone();
                MyCollection shallowCopy = coll1.ShallowCopy();

                coll1.Head.Data.Name = "ИЗМЕНЕНО";

                Console.WriteLine($"В оригинале имя первого элемента: {coll1.Head.Data.Name}");
                Console.WriteLine($"В поверхностной копии (имя тоже изменилось): {shallowCopy.Head.Data.Name}");
                Console.WriteLine($"В глубоком клоне (имя осталось прежним): {deepClone.Head.Data.Name}");

                Console.WriteLine("\n=== Очистка памяти ===");
                coll1.Clear();
                Console.WriteLine($"Количество элементов после Clear(): {coll1.Count}");

            }
        }

    }
}
