using System;
using System.Collections.Generic;

namespace _08._07_RemoveKthLastElementFromList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode node = new ListNode(1);
            node.Next = new ListNode(2);
            node.Next.Next = new ListNode(3);
            node.Next.Next.Next = new ListNode(4);
            node.Next.Next.Next.Next = new ListNode(5);
            node.Next.Next.Next.Next.Next = new ListNode(6);
            node.Next.Next.Next.Next.Next.Next = new ListNode(7);
            
            ListNode current = node;
            while (current != null) {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
            Console.WriteLine();

            DeleteKthFromTheLast(node, 2);

            current = node;
            while (current != null) {
                Console.Write($"{current.Value} ");
                current = current.Next;                
            }
            Console.WriteLine();

            
        }

        static ListNode DeleteKthFromTheLast(ListNode node, int k) {
            ListNode first = node;
            ListNode second = node;
            while (k > 0) {
                first = first.Next;
                if (first == null) {
                    throw new ArgumentException("not enough nodes available to delete");
                }
                k --;
            }
            while (first.Next != null) {
                first = first.Next;
                second = second.Next;
            }
            second.Next = second.Next.Next;
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
