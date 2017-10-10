using System;
using System.Collections.Generic;

namespace _08._10_EvenOddMergeLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list1 = new ListNode(0);
            list1.Next = new ListNode(1);
            list1.Next.Next = new ListNode(2);
            list1.Next.Next.Next = new ListNode(3);
            list1.Next.Next.Next.Next = new ListNode(4);
            list1.Next.Next.Next.Next.Next = new ListNode(5);
            list1.Next.Next.Next.Next.Next.Next = new ListNode(6);

            ListNode merged = EvenOddMerge(list1);
            Console.WriteLine();
            merged.Print();

            list1 = new ListNode(0);
            list1.Next = new ListNode(1);
            list1.Next.Next = new ListNode(2);
            list1.Next.Next.Next = new ListNode(3);
            list1.Next.Next.Next.Next = new ListNode(4);
            list1.Next.Next.Next.Next.Next = new ListNode(5);
            list1.Next.Next.Next.Next.Next.Next = new ListNode(6);

            merged = EvenOddMergeList(list1);
            Console.WriteLine();
            merged.Print();
            
        }

        static ListNode EvenOddMerge(ListNode node) {
            ListNode p1 = node;
            ListNode p2 = node.Next;
            ListNode connectNode = node.Next;

            while (p1 != null && p2 != null) {
                if (p2.Next == null) {
                    break;
                }
                p1.Next = p2.Next;
                p1 = p1.Next;

                p2.Next = p1.Next;
                p2 = p2.Next;
            }

            p1.Next = connectNode;

            return node;
        }

        static ListNode EvenOddMergeList(ListNode node) {
            ListNode evenHead = new ListNode(-1);
            ListNode oddHead = new ListNode(-1);

            List<ListNode> tails = new List<ListNode>();
            tails.Add(evenHead);
            tails.Add(oddHead);
            int turn = 0;
            

            ListNode current = node;
            while (current != null)
            {
                tails[turn].Next = current;
                tails[turn] = tails[turn].Next;
                turn ^= 1;

                current = current.Next;
            }

            tails[1].Next = null;
            tails[0].Next = oddHead.Next;

            return evenHead.Next;
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
