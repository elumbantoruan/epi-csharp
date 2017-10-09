using System;

namespace _08._02_ReverseSingleSublist
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode node = new ListNode(11);
            node.Next = new ListNode(3);
            node.Next.Next = new ListNode(5);
            node.Next.Next.Next = new ListNode(7);
            node.Next.Next.Next.Next = new ListNode(2);

            ListNode reversed = Reverse(node);
            ListNode current = reversed;
            while (current != null) {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }

        }

        static ListNode Reverse(ListNode node) {
            ListNode current = node;
            ListNode prev = null;

            while (current != null) {
                ListNode next = current.Next;
                current.Next = prev;

                prev = current;
                current = next;
            }
            return prev;
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
