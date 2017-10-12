using System;
using System.Collections.Generic;

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
        }

        static int rootIndex = 0;

        static Tree<int> BuildTree(int[] preOrder) {
            return BuildTree(preOrder, Int32.MinValue, Int32.MaxValue);
        }

        static Tree<int> BuildTree(int[] preOrder, int lowerBound, int upperBound) {
            if (rootIndex == preOrder.Length) {
                return null;
            }
            int root = preOrder[rootIndex];
            if (root < lowerBound || root > upperBound) {
                return null;
            }
            rootIndex++;
            Tree<int> left = BuildTree(preOrder, lowerBound, root);
            Tree<int> right = BuildTree(preOrder, root, upperBound);
            Tree<int> rootNode = new Tree<int>(root);
            rootNode.Left = left;
            rootNode.Right = right;

            return rootNode;
        }

    }

    public class Tree<T> where T : IComparable<T> {
        public T Value { get; set; }
        public Tree<T> Left {get;set; }
        public Tree<T> Right { get; set; }
        public Tree(T value)
        {
            Value = value;
        }

        public void Insert(T value) {
            if (value.CompareTo(Value) < 0) {
                if (Left == null) {
                    Left = new Tree<T>(value);
                }
                else {
                    Left.Insert(value);
                }
            }
            else {
                if (Right == null) {
                    Right = new Tree<T>(value);
                }
                else {
                    Right.Insert(value);
                }
            }
        }

        public void PreOrder() {
            Console.Write($"{Value} ");
            if (Left != null) {
                Left.PreOrder();
            }
            if (Right != null) {
                Right.PreOrder();
            }
        }
    }
}
