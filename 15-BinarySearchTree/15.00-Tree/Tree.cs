using System;
using System.Collections.Generic;

namespace _15._00_Tree
{
    public class Tree<T> where T : IComparable<T> {

        private List<T> preOrderList = new List<T>();

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

        public void PostOrder() {
            
            if (Left != null) {
                Left.PreOrder();
            }
            if (Right != null) {
                Right.PreOrder();
            }
            Console.Write($"{Value} ");
        }

        public List<T> ToPreOrderList() {
            List<T> list = new List<T>();
            ToPreOrderList(list);
            return list;
        }

        private void ToPreOrderList(List<T> list) {
            list.Add(Value);
            if (Left != null) {
                Left.ToPreOrderList();
            }
            if (Right != null) {
                Right.ToPreOrderList();
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

        public List<T> ToInOrderList() {
            List<T> list = new List<T>();
            ToInOrderList(list);
            return list;
        }

        private void ToInOrderList(List<T> list) {
            if (Left != null) {
                Left.ToInOrderList(list);
            }
            list.Add(Value);       
            if (Right != null) {
                Right.ToInOrderList(list);
            }
        }
    }
}
