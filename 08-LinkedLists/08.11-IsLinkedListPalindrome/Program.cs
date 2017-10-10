using System;

namespace _08._11_IsLinkedListPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list = new ListNode(1);
            list.Next = new ListNode(2);
            list.Next.Next = new ListNode(3);
            list.Next.Next.Next = new ListNode(2);
            list.Next.Next.Next.Next = new ListNode(1);

            Console.WriteLine($"IsPalindrome: {IsLinkedListPalindrome(list)} ");

            list = new ListNode(1);
            list.Next = new ListNode(2);
            list.Next.Next = new ListNode(3);
            list.Next.Next.Next = new ListNode(2);
            list.Next.Next.Next.Next = new ListNode(4);

            Console.WriteLine($"IsPalindrome: {IsLinkedListPalindrome(list)} ");
        }

        static bool IsLinkedListPalindrome(ListNode node) {
            ListNode slow = node;
            ListNode fast = node; 
            while (fast != null && fast.Next != null) {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            ListNode reversed = Reverse(slow);
            ListNode firstHalf = node;
            while (firstHalf != null && reversed != null) {
                if (reversed.Value != firstHalf.Value) {
                    return false;
                }
                reversed = reversed.Next;
                firstHalf = firstHalf.Next;
            }
            return true;
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

        public ListNode()
        {
        }

        public void Print() {
            ListNode current = this;
            while (current != null) {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
        }
    }
}
