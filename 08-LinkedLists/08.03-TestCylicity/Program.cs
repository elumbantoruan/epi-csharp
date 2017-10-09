using System;

namespace _08._03_TestCylicity
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(1);
            l1.Next = new ListNode(2);
            l1.Next.Next = new ListNode(3);
            l1.Next.Next.Next = new ListNode(4);
            l1.Next.Next.Next.Next = new ListNode(5);
            l1.Next.Next.Next.Next.Next = l1.Next;

            ListNode cycleNode = HasCycle(l1);
            Console.WriteLine($"Cycle node: {(cycleNode == null ? "none" : cycleNode.Value.ToString())}");
        }

        static ListNode HasCycle(ListNode node) {
            ListNode slow = node;
            ListNode fast = node;

            while (fast != null && fast.Next != null) {
                
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast) {
                    break;
                }
            }

            if (fast == null || fast.Next == null) {
                return null;
            }

            slow = node;
            while (slow != fast) {
                slow = slow.Next;
                fast = fast.Next;
            }
            return slow;
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
