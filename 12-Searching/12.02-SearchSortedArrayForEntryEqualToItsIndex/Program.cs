using System;
using System.Diagnostics;

namespace _12._02_SearchSortedArrayForEntryEqualToItsIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {-2, 0, 2, 3, 6, 7, 9};
            int index = SearchSortedArrayForEntryEqualToIndex(numbers);
            Console.WriteLine(index);
        }

        static int SearchSortedArrayForEntryEqualToIndex(int[] numbers) {
            int index = -1;
            int start = 0;
            int end = numbers.Length - 1;

            while (start <= end) {
                int mid = start + (end - start) / 2;
                if (numbers[mid] == mid) {
                    return mid;
                }
                else if (numbers[mid] < mid) {
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
