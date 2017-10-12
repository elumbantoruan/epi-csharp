using System;

namespace _15._02_FindTheFirstKeyGreaterThanGivenValue
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

            Tree<int> result = FindFirstGreaterThanK(tree, 23);
            Console.WriteLine(result.Value);
        }

        /*
            Perform binary search, keeping some additional state
            Store the best candidate for the result and update
            that candidate as we iteratively descend the tree, 
            eliminating subtrees by comparing the keys stored at nodes
            with the input value.  Move to left tree if the current value
            is greater than k, and vice versa move to the right is it's less than K

            Time complexity is O(h) where h is the heigth of the tree.
            The space complexity is O(1)
         */
        static Tree<T> FindFirstGreaterThanK<T>(Tree<T> root, T k) where T : IComparable<T> {
            Tree<T> current = root;
            Tree<T> firstGreaterSoFar = null;

            while (current != null) {
                if (current.Value.CompareTo(k) > 0) {
                    firstGreaterSoFar = current;
                    current = current.Left;
                }
                else {
                    current = current.Right;
                }
            }
            return firstGreaterSoFar;
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
