using System;
using System.Collections.Generic;

namespace _15._09_BuildMinimumBSTFromSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            Tree<int> tree = BuildBSTFromSortedList(list, 0, list.Count);
            tree.PreOrder();
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

        public void InOrder() {
            if (Left != null) {
                Left.InOrder();
            }
            Console.Write($"{Value} ");            
            if (Right != null) {
                Right.InOrder();
            }
        }
    }
}
