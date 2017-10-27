using System;
using System.Collections.Generic;
using System.Diagnostics;
using _15._00_Tree;

namespace _15._05_ReconstructBSTFromPreOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] preOrder = new int[]
            {
                19, 7, 3, 2, 5, 11, 17, 13, 43, 23, 37, 29, 31, 41, 47, 53
            };
            Tree<int> tree = BuildTree(preOrder);
            Console.WriteLine();
            tree.PreOrder();
            Console.WriteLine();            
            List<int> resultsOfPreOrder = tree.ToPreOrderList();
            for (int i = 0; i < resultsOfPreOrder.Count; i++)
            {
                Debug.Assert(resultsOfPreOrder[i] == preOrder[i]);
            }
        }

        static Tree<int> BuildTree(int[] preOrder) {
            return BuildTree(preOrder, 0, preOrder.Length);
        }

        static Tree<int> BuildTree(int[] preOrder, int start, int end) {
            if (start >= end) {
                return null;
            }
            int transpoint = start + 1;
            while (transpoint < end) {
                if (preOrder[transpoint] < preOrder[start]) {
                    transpoint++;
                }
                else {
                    break;
                }
            }
            Tree<int> rootNode = new Tree<int>(preOrder[start]);
            rootNode.Left = BuildTree(preOrder, start + 1, transpoint);
            rootNode.Right = BuildTree(preOrder, transpoint, end);
            return rootNode;
        }
    }
}
