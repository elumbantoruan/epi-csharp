using System;

namespace _08._12_LinkedListPivoting
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode<int> list = new ListNode<int>(3);
            list.Next = new ListNode<int>(2);
            list.Next.Next = new ListNode<int>(2);
            list.Next.Next.Next = new ListNode<int>(11);
            list.Next.Next.Next.Next = new ListNode<int>(7);
            list.Next.Next.Next.Next.Next = new ListNode<int>(5);
            list.Next.Next.Next.Next.Next.Next = new ListNode<int>(11);

            list.Print();

            ListNode<int> pivotedList = ListPivoting(list, 7);

            pivotedList.Print();
        }

        /*
            List to be pivoted:
            {3, 2, 2, 11, 7, 5, 11}

            Pivoted list:
            {3, 2, 2, 5, 7, 11, 11}

         */
        static ListNode<T> ListPivoting<T>(ListNode<T> node, T k) where T : IComparable<T> {
            ListNode<T> lessHead = new ListNode<T>();
            ListNode<T> equalHead = new ListNode<T>();
            ListNode<T> greaterHead = new ListNode<T>();

            ListNode<T> lessIterator = lessHead;
            ListNode<T> equalIterator = equalHead;
            ListNode<T> greaterIterator = greaterHead;

            ListNode<T> current = node;

            while (current != null) {

                if (current.Value.CompareTo(k) < 0) {
                    lessIterator.Next = new ListNode<T>(current.Value);
                    lessIterator = lessIterator.Next;
                }
                else if (current.Value.CompareTo(k) == 0) {
                    equalIterator.Next = new ListNode<T>(current.Value);
                    equalIterator = equalIterator.Next;
                }
                else {
                    greaterIterator.Next = new ListNode<T>(current.Value);
                    greaterIterator = greaterIterator.Next;
                }
                current = current.Next;
            }

            // combine
            greaterIterator.Next = null;
            equalIterator.Next = greaterHead.Next;            
            lessIterator.Next = equalHead.Next;

            return lessHead.Next;

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
