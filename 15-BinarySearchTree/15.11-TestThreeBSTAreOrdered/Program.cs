using System;

namespace _15._11_TestThreeBSTAreOrdered
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
