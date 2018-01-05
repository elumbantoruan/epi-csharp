using System;
using System.Diagnostics;
using BinaryTree;

namespace _10._01_TestBinaryTreeHeightBalanced
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode tree = new TreeNode(10);
            tree.Left = new TreeNode(5);
            tree.Right = new TreeNode(30);
            tree.Right.Left = new TreeNode(20);
            tree.Right.Right = new TreeNode(35);
            tree.Right.Right.Right = new TreeNode(40);

            bool balanced = IsBalanced(tree);
            Console.WriteLine($"IsBalanced = {balanced} ");
            Debug.Assert(balanced == false);

            tree = new TreeNode(10);
            tree.Left = new TreeNode(5);
            tree.Right = new TreeNode(30);
            tree.Right.Left = new TreeNode(20);

            balanced = IsBalanced(tree);
            Console.WriteLine($"IsBalanced = {balanced} ");
            Debug.Assert(balanced == true);
            
        }

        static bool IsBalanced(TreeNode node) {
            if (node == null) {
                return true;
            }
            int leftHeight = Height(node.Left);
            int rightHeight = Height(node.Right);
            if (Math.Abs(leftHeight - rightHeight) > 1) {
                return false;
            }
            return IsBalanced(node.Left) && IsBalanced(node.Right);
        }

        static int Height(TreeNode node) {
            if (node == null) {
                return 0;
            }

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }
    }
}
