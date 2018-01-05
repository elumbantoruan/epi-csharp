using System;
using System.Collections.Generic;

namespace _10._04_ComputeLCAUsingParentNode
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode node = new TreeNode(314);
            node.Left = new TreeNode(6);
            node.Left.Left = new TreeNode(271);
            node.Left.Left.Left = new TreeNode(28);
            node.Left.Left.Right = new TreeNode(0);
            node.Left.Right = new TreeNode(561);
            node.Left.Right.Right = new TreeNode(3);
            node.Left.Right.Right.Left = new TreeNode(17);

            node.Right = new TreeNode(6);
            node.Right.Parent = node;

            node.Right.Left = new TreeNode(2);
            node.Right.Left.Parent = node.Right;

            node.Right.Left.Right = new TreeNode(1);
            node.Right.Left.Right.Parent = node.Right.Left;

            node.Right.Left.Right.Left = new TreeNode(401);
            node.Right.Left.Right.Left.Parent = node.Right.Left.Right;

            node.Right.Left.Right.Left.Right = new TreeNode(641);
            node.Right.Left.Right.Left.Right.Parent = node.Right.Left.Right.Left;

            node.Right.Left.Right.Right = new TreeNode(257);
            node.Right.Left.Right.Right.Parent = node.Right.Left.Right;

            node.Right.Right = new TreeNode(271);
            node.Right.Right.Parent = node.Right;

            node.Right.Right.Right = new TreeNode(28);
            node.Right.Right.Right.Parent = node.Right.Right;

            TreeNode lcaUseMap = FindLCA(node.Right.Right.Right,
                node.Right.Left.Right.Left.Right);

            Console.WriteLine(lcaUseMap.Value);

            TreeNode lca = FindLCA(node.Right.Right.Right,
                node.Right.Left.Right.Left.Right);

            Console.WriteLine(lca.Value);

        }

        static TreeNode FindLCAUsingMap(TreeNode node0, TreeNode node1) {
            Dictionary<int,TreeNode> map = new Dictionary<int, TreeNode>();
            while (node0 != null) {
                map.Add(node0.Value, node0);
                node0 = node0.Parent;
            }
            while (node1 != null) {
                if (map.ContainsKey(node1.Value)) {
                    return map[node1.Value];
                }
                node1 = node1.Parent;
            }
            return null;
        }

        static TreeNode FindLCA(TreeNode node0, TreeNode node1) {
            int h0 = Height(node0);
            int h1 = Height(node1);
            if (h1 > h0) {
                TreeNode temp = node0;
                node0 = node1;
                node1 = temp;
            }
            int heightDiff = Math.Abs(h1 - h0);
            while (heightDiff > 0) {
                node0 = node0.Parent;
                heightDiff--;
            }
            while (node0 != node1) {
                node0 = node0.Parent;
                node1 = node1.Parent;
            }
            return node0;
        }

        static int Height(TreeNode node) {
            int height = 0;
            while (node != null) {
                node = node.Parent;
                height++;
            }
            return height;
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode Parent {get;set;}

        public TreeNode(int value)
        {
            Value = value;
        }
    }
}
