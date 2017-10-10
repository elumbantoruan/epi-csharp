using System;

namespace _08._06_DeleteANodeFromSinglyLinkedList
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
            
            ListNode current = node;
            while (current != null) {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
            DeleteNode(node.Next);
            Console.WriteLine();

            current = node;
            while (current != null) {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
        }

        static void DeleteNode(ListNode node) {
            node.Value = node.Next.Value;
            node.Next = node.Next.Next;
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
