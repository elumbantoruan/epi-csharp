using System;
using System.Collections.Generic;
using System.Diagnostics;
using _15._00_Tree;

namespace _15._03_FindTheKLargestElements
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(19);
            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(11);
            tree.Insert(17);
            tree.Insert(13);

            tree.Insert(43);
            tree.Insert(23);
            tree.Insert(37);
            tree.Insert(29);
            tree.Insert(41);
            tree.Insert(31);
            tree.Insert(47);
            tree.Insert(53);

            List<int> results = FindTheKLargestElements(tree, 3);
            foreach (var item in results)
            {
                Console.Write($"{item} ");
            }
            List<int> expected = new List<int> {53,47,43};
            for (int i = 0; i < expected.Count; i++) {
                Debug.Assert(expected[i] == results[i]);
            }
        }

        static List<int> FindTheKLargestElements(Tree<int> tree, int k) {
            List<int> list = new List<int>();
            FindTheKLargestElements(tree, k, list);
            return list;
        }

        static void FindTheKLargestElements(Tree<int> tree, int k, List<int> list) {
            if (tree != null && list.Count < k) {
                FindTheKLargestElements(tree.Right, k, list);
                if (list.Count < k) {
                    list.Add(tree.Value);
                    FindTheKLargestElements(tree.Left, k, list);
                }    
            }
        }
    }
}
