using System;
using System.Collections.Generic;
using System.Diagnostics;
using _15._00_Tree;

namespace _15._12_RangeLookupProblem
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

            Console.WriteLine();
            List<int> list = RangeLookup(tree, new Interval<int> { Left = 16, Right = 31});
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            List<int> expected = new List<int>{17,19,23,29,31};
            for (int i = 0; i < expected.Count; i++) {
                Debug.Assert(expected[i] == list[i]);
            }
        }

        static List<T> RangeLookup<T>(Tree<T> root, Interval<T> interval) where T : IComparable<T> {
            List<T> list = new List<T>();
            RangeLookup(root, interval, list);
            return list;
        }

        static void RangeLookup<T>(Tree<T> root, Interval<T> interval, List<T> list) where T : IComparable<T> {
            if (root == null) {
                return;
            }
            if (interval.Left.CompareTo(root.Value) <= 0 && root.Value.CompareTo(interval.Right) <= 0) {
                RangeLookup(root.Left, interval, list);
                list.Add(root.Value);
                RangeLookup(root.Right, interval, list);
            }    
            else if (interval.Left.CompareTo(root.Value) > 0) {
                RangeLookup(root.Right, interval, list);
            }
            else { //(interval.Right.CompareTo(root.Value) >= 0) {
                RangeLookup(root.Left, interval, list);
            }
        }
    }

    public class Interval<T> where T : IComparable<T> {
        public T Left { get; set; }
        public T Right { get; set; }
    }
}
