using System;
using BinaryTree;

namespace _10._06_FindRootToLeafWithSpecifiedSum
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(314);
            root.Left = new TreeNode(6);
            root.Left.Left = new TreeNode(271);
            root.Left.Left.Left = new TreeNode(28);
            root.Left.Left.Right = new TreeNode(0);

            root.Left.Right = new TreeNode(561);
            root.Left.Right.Right = new TreeNode(3);
            root.Left.Right.Right.Left = new TreeNode(17);

            root.Right = new TreeNode(6);
            root.Right.Left = new TreeNode(2);
            root.Right.Left.Right = new TreeNode(1);
            root.Right.Left.Right.Left = new TreeNode(401);
            root.Right.Left.Right.Left.Right = new TreeNode(641);
            root.Right.Left.Right.Right = new TreeNode(257);

            root.Right.Right = new TreeNode(271);
            root.Right.Right.Right = new TreeNode(28);

            bool hasPathSum = HasPathSum(root, 591);
            Console.WriteLine(hasPathSum);

        }

        static bool HasPathSum(TreeNode node, int target) {
            return HasPathSum(node, 0, target);
        }

        static bool HasPathSum(TreeNode node, int partialSum, int target) {
            if (node == null) {
                return false;
            }
            partialSum += node.Value;
            if (node.Left == null && node.Right == null) {
                return partialSum == target;
            }
            return HasPathSum(node.Left, partialSum, target) ||
                   HasPathSum(node.Right, partialSum, target);
        }
    }
}
