using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesLibrary
{
    public class BinaryTree
    {
        public TreeNode Root { get; private set; }

        public void BuildIdealBalanced(List<Place> items)
        {
            Root = BuildIdealBalancedRecursive(items, 0, items.Count - 1);
        }

        private TreeNode BuildIdealBalancedRecursive(List<Place> items, int start, int end)
        {
            if (start > end) return null;

            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(items[mid]);

            node.Left = BuildIdealBalancedRecursive(items, start, mid - 1);
            node.Right = BuildIdealBalancedRecursive(items, mid + 1, end);

            return node;
        }

        public void PrintTree(string message)
        {
            Console.WriteLine($"\n--- {message} ---");
            if (Root == null)
            {
                Console.WriteLine("Дерево пусто.");
                return;
            }
            PrintTreeRecursive(Root, 0);
        }

        private void PrintTreeRecursive(TreeNode node, int level)
        {
            if (node != null)
            {
                PrintTreeRecursive(node.Right, level + 1);

                Console.Write(new string(' ', level * 6));
                if (node.Data is City city)
                    Console.WriteLine($"[{city.Name}: {city.Population}]");
                else
                    Console.WriteLine($"[{node.Data.Name}]");

                PrintTreeRecursive(node.Left, level + 1);
            }
        }

        public double GetAveragePopulation()
        {
            int totalPopulation = 0;
            int cityCount = 0;

            CalculatePopulationRecursive(Root, ref totalPopulation, ref cityCount);

            if (cityCount == 0) return 0;
            return (double)totalPopulation / cityCount;
        }

        private void CalculatePopulationRecursive(TreeNode node, ref int totalPopulation, ref int cityCount)
        {
            if (node == null) return;

            if (node.Data is City city)
            {
                totalPopulation += city.Population;
                cityCount++;
            }

            CalculatePopulationRecursive(node.Left, ref totalPopulation, ref cityCount);
            CalculatePopulationRecursive(node.Right, ref totalPopulation, ref cityCount);
        }

        public void ConvertToSearchTree()
        {
            List<Place> allItems = new List<Place>();
            CollectItemsRecursive(Root, allItems);

            Root = null;

            foreach (var item in allItems)
            {
                InsertToSearchTree(item);
            }
        }

        private void CollectItemsRecursive(TreeNode node, List<Place> list)
        {
            if (node == null) return;
            list.Add(node.Data);
            CollectItemsRecursive(node.Left, list);
            CollectItemsRecursive(node.Right, list);
        }

        public void InsertToSearchTree(Place data)
        {
            Root = InsertRecursive(Root, data);
        }

        private TreeNode InsertRecursive(TreeNode node, Place data)
        {
            if (node == null) return new TreeNode(data);

            int compareResult = data.CompareTo(node.Data);

            if (compareResult < 0)
                node.Left = InsertRecursive(node.Left, data);
            else
                node.Right = InsertRecursive(node.Right, data);

            return node;
        }

        public void Clear()
        {
            Root = ClearRecursive(Root);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("\n[Система]: Дерево полностью удалено из памяти.");
        }

        private TreeNode ClearRecursive(TreeNode node)
        {
            if (node == null) return null;

            node.Left = ClearRecursive(node.Left);
            node.Right = ClearRecursive(node.Right);

            node.Data = null;

            return null;
        }
    }
}
