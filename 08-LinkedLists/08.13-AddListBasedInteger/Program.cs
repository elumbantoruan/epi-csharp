using System;
using System.Collections.Generic;

namespace _08._13_AddListBasedInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode<int> list1 = new ListNode<int>(3);
            list1.Next = new ListNode<int>(1);
            list1.Next.Next = new ListNode<int>(4);

            ListNode<int> list2 = new ListNode<int>(7);
            list2.Next = new ListNode<int>(0);
            list2.Next.Next = new ListNode<int>(9);

            Console.WriteLine("list1");
            list1.Print();
            Console.WriteLine();
            Console.WriteLine("list2");
            list2.Print();
            Console.WriteLine();

            ListNode<int> list = AddTwoNumbers(list1, list2);

            ListNode<int> list3 = new ListNode<int>(7);
            list3.Next = new ListNode<int>(0);
            list3.Next.Next = new ListNode<int>(9);
            list3.Next.Next.Next = new ListNode<int>(2);
            

            Console.WriteLine("list3");
            list3.Print();
            Console.WriteLine();
            list = AddTwoNumbers(list1, list3);

            list.Print();
        }

        /*
            L1 {3, 1, 4}
            L2 {7, 0, 9}

            3+7 = 0 (carryover 1)
            1+0 = 2 (1 + carryover)

            4+9 = 3 (carryover 1)
            
            1 (from carryover)

            Result {0, 2, 3, 1}
         */
        static ListNode<int> AddTwoNumbers(ListNode<int> list1, ListNode<int> list2)
        {
            ListNode<int> result = new ListNode<int>();
            ListNode<int> iterator = result;

            int carryover = 0;
            while (list1 != null || list2 != null) {
                int sum = carryover;

                if (list1 != null) {
                    sum += list1.Value;
                    list1 = list1.Next;
                }

                if (list2 != null) {
                    sum += list2.Value;
                    list2 = list2.Next;
                }

                iterator.Next = new ListNode<int>(sum % 10);
                carryover = sum / 10;
                
                iterator = iterator.Next;
            }

            if (carryover > 0) {
                iterator.Next = new ListNode<int>(carryover);
                iterator = iterator.Next;
            }

            return result.Next;
        }
    }

    public class ListNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public ListNode<T> Next { get; set; }

        public ListNode()
        {
        }

        public ListNode(T value)
        {
            Value = value;
        }

        public ListNode(T value, ListNode<T> next)
        {
            Value = value;
            Next = next;
        }

        public void Print()
        {
            ListNode<T> current = this;
            while (current != null)
            {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        
    }
}
