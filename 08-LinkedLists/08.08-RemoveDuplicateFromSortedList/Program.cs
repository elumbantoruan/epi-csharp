using System;

namespace _08._08_RemoveDuplicateFromSortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list1 = new ListNode(2);
            list1.Next = new ListNode(2);
            list1.Next.Next = new ListNode(3);
            list1.Next.Next.Next = new ListNode(5);
            list1.Next.Next.Next.Next = new ListNode(7);
            list1.Next.Next.Next.Next.Next = new ListNode(11);
            list1.Next.Next.Next.Next.Next.Next = new ListNode(11);

            Console.WriteLine("list1");
            list1.Print();
            Console.WriteLine("Remove duplicate");
            ListNode removedDup = RemoveDuplicate(list1);
            removedDup.Print();
        }

        static ListNode RemoveDuplicate(ListNode list1) {
            ListNode current = list1;
            while (current != null && current.Next != null) {
                if (current.Value == current.Next.Value) {
                    current.Next = current.Next.Next;
                }
                current = current.Next;               
            }
            return list1;
        }
    }

    public class ListNode {
        public int Value { get; set; }
        public ListNode Next { get; set; }
        public ListNode(int value)
        {
            Value = value;
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
