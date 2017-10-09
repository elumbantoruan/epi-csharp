using System;

namespace _08._01_MergeTwoSortedLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(2);
            l1.Next = new ListNode(5);
            l1.Next.Next = new ListNode(7);

            ListNode l2 = new ListNode(3);
            l2.Next = new ListNode(11);

            ListNode mergedList = MergeSortedList(l1, l2);
            ListNode current = mergedList;
            while (current != null) {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
        }

        static ListNode MergeSortedList(ListNode l1, ListNode l2) {
            ListNode mergedList = new ListNode(-1);
            ListNode iterator = mergedList;

            while (l1 != null && l2 !=  null) {
                if (l1.Value < l2.Value) {
                    iterator.Next = new ListNode(l1.Value);
                    iterator = iterator.Next;
                    l1 = l1.Next;
                }
                else {
                    iterator.Next = new ListNode(l2.Value);
                    iterator = iterator.Next;
                    l2 = l2.Next;
                }
            }

            iterator.Next =  (l1 == null ? l2 : l1);

            return mergedList.Next;
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
