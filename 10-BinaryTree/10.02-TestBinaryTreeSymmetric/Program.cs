using System;
using System.Diagnostics;
using BinaryTree;

namespace _10._02_TestBinaryTreeSymmetric
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode tree = new TreeNode(1);
            tree.Left = new TreeNode(2);
            tree.Left.Left = new TreeNode(3);
            tree.Left.Right = new TreeNode(4);

            tree.Right = new TreeNode(2);
            tree.Right.Right = new TreeNode(3);
            tree.Right.Left = new TreeNode(4);

            bool isSymmetric = IsSymmetric(tree);
            Debug.Assert(isSymmetric == true);

            tree = new TreeNode(1);
            tree.Left = new TreeNode(2);
            tree.Left.Right = new TreeNode(3);

            tree.Right = new TreeNode(2);
            tree.Right.Right = new TreeNode(3);

            isSymmetric = IsSymmetric(tree);
            Debug.Assert(isSymmetric == false);

        }

        /*
                1
              /   \
             2     2
            / \   / \
           3   4 4   3
         */
        static bool IsSymmetric(TreeNode node) {
            return IsSymmetric(node.Left, node.Right);
        }

        static bool IsSymmetric(TreeNode left, TreeNode right) {
            if (left == null && right == null) {
                return true;
            }
            if (left == null || right == null) {
                return false;
            }
            if (left.Value != right.Value) {
                return false;
            }
            return IsSymmetric(left.Right, right.Left) &&
                   IsSymmetric(right.Left, left.Right);
        }
    }
}
