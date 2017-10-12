using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _12._01_SearchSortedArrayForFirstOccurence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {-14, -10, 2, 108, 108, 243, 285, 285, 285, 401};
            int index = SearchForFirstOccurenceOfK(numbers, 285);
            Console.WriteLine(index);
            Debug.Assert(index == 6);

            index = SearchForFirstOccurenceOfK(numbers, 108);
            Console.WriteLine(index);
            Debug.Assert(index == 3);
        }

        /*
            once we find K, then we set the upper limit to mid - 1 because
            the rest will not be the first occurence anymore
            Time complexity is O(log n)
         */
        static int SearchForFirstOccurenceOfK(int[] numbers, int k) {
            int index = -1;
            int start = 0;
            int end = numbers.Length - 1;

            while (start <= end) {
                int mid = start + (end - start) /2;
                if (numbers[mid] == k) {
                    index = mid;
                    end = mid - 1;
                }
                else if (numbers[mid] < k) {
                    start = mid + 1;
                }
                else {
                    end = mid;
                }
            }
            return index;
            
        }
    }
}
