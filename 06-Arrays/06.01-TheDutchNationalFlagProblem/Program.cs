using System;
using System.Collections.Generic;

namespace _06._01_TheDutchNationalFlagProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Color> colors = new List<Color> {
                Color.Blue,
                Color.Red,
                Color.Red,
                Color.Blue,
                Color.White,
                Color.Red,
                Color.White
            };
            DutchFlagPartition3(1, colors);
            foreach (var item in colors) {
                Console.WriteLine($"{item}");
            }
            
        }

        /*
            Given unsorted array, sort the array based on the pivot index
            so the element of in pivot element stays together

            Given: list of A = {0,1,2,0,2,1,1}
            pivot index 3  A[3] = 0
            result: {0,0,1,2,2,1,1}

            pivot index 2  A[2] = 2
            result: {0,1,0,1,1,2,2} or {0,0,1,1,1,2,2}
         */
        static void DutchFlagPartition(int pivotIndex, List<Color> list) {
            Color pivot = list[pivotIndex];
            // first pass, group elements smaller than pivot
            int smaller = 0;
            for (int i = 0; i < list.Count; i++) {
                if ((int)list[i] < (int)pivot) {
                    Swap(list, smaller++, i);
                }
            }

            // second pass, group elements larger than pivot
            int larger = list.Count - 1;
            for (int i = list.Count - 1; i >= 0; i--) {
                if ((int)list[i] >= (int)pivot) {
                    if ((int)list[i] > (int)pivot) {
                        Swap(list, larger--, i);
                    }
                }
            }
        }

        static void DutchFlagPartition2(int pivotIndex, List<Color> list) {
            Color pivot = list[pivotIndex];

            /*
                Keep the following invariants during partitioning
                bottom goup; A sublist(0, smaller)
                middle group: A sublist (smaller, equal)
                unclassified: A sublist (equal, larger)
                top: A sublist(larger, A.Count)
             */
             int smaller = 0;
             int equal = 0;
             int larger = list.Count;

             while (equal < larger) {
                 if ((int)list[equal] < (int)pivot) {
                     Swap(list, smaller, equal);
                     smaller++;
                     equal++;
                 }
                 else if ((int)list[equal] == (int)pivot) {
                     equal++;
                 }
                 else {
                     Swap(list, equal, larger);
                     larger--;
                 }
             }
        }

        static void DutchFlagPartition3(int pivotIndex, List<Color> list) {
            int i = 0;
            int j = 0;
            int n = list.Count - 1;

            Color pivot = list[pivotIndex];

            while (j < n) {
                if ((int)list[j] < (int)pivot) {
                    Swap(list, i, j);
                    i++;
                    j++;
                }
                else if ((int)list[j] > (int)pivot) {
                    Swap(list, j, n);
                    n--;
                }
                else {
                    j++;
                }
            }
        }

        static void Swap(List<Color> list, int a, int b) {
            Color temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
    }

    public enum Color { Red, White, Blue};
}
