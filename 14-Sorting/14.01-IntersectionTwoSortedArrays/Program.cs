using System;
using System.Collections.Generic;

namespace _14._01_IntersectionTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int> {2, 3, 3, 5, 5, 6, 7, 7, 8, 12};
            List<int> list2 = new List<int> {5, 5, 6, 8, 8, 9, 10, 10};
            List<int> intersections = IntersectionTwoSortedArrays(list1, list2);
            foreach (var item in intersections)
            {
                Console.Write($"{item} ");
            }
        }

        static List<int> IntersectionTwoSortedArrays(List<int> list1, List<int> list2) {
            List<int> intersections = new List<int>();
            int index1 = 0;
            int index2 = 0;
            while (index1 < list1.Count && index2 < list2.Count) {
                if (list1[index1] == list2[index2]) {//} && index1 == 0 || list1[index1] != list1[index1 - 1]) {
                    if (!intersections.Contains(list1[index1])) {
                        intersections.Add(list1[index1]);
                    }
                    index1++;
                    index2++;
                }
                else if (list1[index1] < list2[index2]) {
                    index1++;
                }
                else {
                    index2++;
                }
            }
            return intersections;
        }
    }
}
