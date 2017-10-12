using System;

namespace _15._01_ValidateBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(20);
            tree.Left = new Tree<int>(10);
            tree.Left.Left = new Tree<int>(15);
            tree.Right = new Tree<int>(30);

            bool isBst = IsBST(tree);

            Console.WriteLine(isBst);

            tree = new Tree<int>(20);
            tree.Left = new Tree<int>(10);
            tree.Left.Left = new Tree<int>(5);
            tree.Right = new Tree<int>(30);

            isBst = IsBST(tree);

            Console.WriteLine(isBst);
        }

        static bool IsBST(Tree<int> root) {
            return IsBST(root, Int32.MinValue, Int32.MaxValue);
        }

        static bool IsBST(Tree<int> root, int minValue, int maxValue) {
            if (root == null) {
                return true;
            }
            if (root.Value < minValue || 
                root.Value > maxValue) {
                return false;
            }
            return IsBST(root.Left, minValue, root.Value) &&
                   IsBST(root.Right, root.Value, maxValue);
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
    }
}
