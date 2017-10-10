using System;

namespace _08._09_CyclicRightShiftSinglyLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list1 = new ListNode(1);
            list1.Next = new ListNode(2);
            list1.Next.Next = new ListNode(3);
            list1.Next.Next.Next = new ListNode(4);
            list1.Next.Next.Next.Next = new ListNode(5);

            Console.WriteLine("list1");
            list1.Print();
            Console.WriteLine("Shift right");
            ListNode shiftedList = ShiftRight(list1, 3);
            shiftedList.Print();
            

        }

        /*
         * 1 -> 2 -> 3 -> 4 -> 5
         * shift 3
         * 3 -> 4 -> 5 -> 1 -> 2
         * 
         */
        static ListNode ShiftRight(ListNode list, int k) 
        {
            int n = 1;
            ListNode tail = list;
            while (tail.Next != null) {
                n++;
                tail = tail.Next;
            }
            k = k % n;
            if (k == 0) {
                return list;
            }
            
            tail.Next = list;   // makes a cycle by connecting the tail to the head
            ListNode newTail = tail;
            int stepsToNewHead = n - k;
            while (stepsToNewHead > 0) {
                newTail = newTail.Next;
                stepsToNewHead--;
            }
            ListNode newNode = newTail.Next;
            newTail.Next = null;

            return newNode;           
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
