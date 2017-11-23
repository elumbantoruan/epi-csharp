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
            DutchFlagPartitionWithPivot(1, colors);
            foreach (var item in colors) {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine();

            colors = new List<Color> {
                Color.Blue,
                Color.Red,
                Color.Red,
                Color.Blue,
                Color.White,
                Color.Red,
                Color.White
            };
            DutchFlagPartitionWithoutPivot(colors);
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
    
            Keep the following invariants during partitioning
            bottom goup; A sublist(0, smaller)
            middle group: A sublist (smaller, equal)
            unclassified: A sublist (equal, larger)
            top: A sublist(larger, A.Count)
        */
        static void DutchFlagPartitionWithPivot(int pivotIndex, List<Color> list) {
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
                else if ((int)list[j] == (int)pivot) {
                    j++;
                }
                else if ((int)list[j] > (int)pivot) {
                    Swap(list, j, n);
                    n--;
                }
            }
        }

        static void DutchFlagPartitionWithoutPivot(List<Color> colors) {
            int i = 0;
            int j = 0;
            int n = colors.Count - 1;

            while (j < n) {
                if (colors[j] == Color.Red) {
                    Swap(colors, i, j);
                    i++;
                    j++;
                }
                else if (colors[j] == Color.White) {
                    j++;
                }
                else if (colors[j] == Color.Blue) {
                    Swap(colors, j, n);
                    n--;
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
