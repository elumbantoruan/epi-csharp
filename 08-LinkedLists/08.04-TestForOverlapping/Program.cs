using System;

namespace _08._04_TestForOverlapping
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(4);
            l1.Next = new ListNode(5);
            l1.Next.Next = new ListNode(6);
            l1.Next.Next.Next = new ListNode(7);
            l1.Next.Next.Next.Next = new ListNode(8);

            ListNode l2 = new ListNode(1);
            l2.Next = l1.Next.Next;

            ListNode overlapping = FindOverlapping(l1, l2);
            Console.WriteLine($"{(overlapping == null ? "none" : overlapping.Value.ToString())}");
        }

        static ListNode FindOverlapping(ListNode node1, ListNode node2) {
            int lengthNode1 = Length(node1);
            int lengthNode2 = Length(node2);
            if (lengthNode1 > lengthNode2) {
                node1 = AdvanceTheNode(node1, lengthNode1 - lengthNode2);
            }
            else {
                node2 = AdvanceTheNode(node2, lengthNode2 - lengthNode1);
            }
            while (node1 != null && node2 != null) {
                if (node1.Value == node2.Value) {
                    return node1;
                }
                node1 = node1.Next;
                node2 = node2.Next;
            }
            return null;
        }

        static int Length(ListNode node) {
            int length = 0;
            ListNode current = node;
            while (current != null) {
                current = current.Next;
                length++;
            }
            return length;
        }

        static ListNode AdvanceTheNode(ListNode node, int n) {
            while (n > 0) {
                node = node.Next;
                n--;
            }
            return node;
        }
    }

    public class ListNode {
        public int Value { get; set; }
        public ListNode Next { get; set; }
        public ListNode(int value)
        {
            Value = value;
        }
    }
}
