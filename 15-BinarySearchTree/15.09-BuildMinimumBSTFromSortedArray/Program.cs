using System;
using System.Collections.Generic;
using System.Diagnostics;
using _15._00_Tree;

namespace _15._09_BuildMinimumBSTFromSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            Tree<int> tree = BuildBSTFromSortedList(list, 0, list.Count);
            tree.InOrder();
            List<int> inOrderList = tree.ToInOrderList();
            for (int i = 0; i < inOrderList.Count; i++) {
                Debug.Assert(inOrderList[i] == list[i]);
            }
        }

        /*
            Time complexity T(n) = 2T(n/2) + O(1), which solves T(n) to O(n)
         */
        static Tree<int> BuildBSTFromSortedList(List<int> list, int start, int end) {
            if (start >= end) {
                return null;
            }

            int mid = start + (end - start) / 2;
            Tree<int> tree = new Tree<int>(list[mid]);
            tree.Left = BuildBSTFromSortedList(list, start, mid);
            tree.Right = BuildBSTFromSortedList(list, mid + 1, end);
            return tree;
        }
    }
}
