using System;

namespace _12._03_SearchCyclicallySortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {378, 478, 550, 631, 103, 203, 220, 234, 279, 368};
            int index = SearchCyclicallySortedArray(numbers);
            Console.WriteLine(index);
        }

        static int SearchCyclicallySortedArray(int[] numbers) {
            int start = 0;
            int end = numbers.Length - 1;
            

            while (start <= end) {
                int mid = start + (end - start) / 2;
                if (numbers[mid] < numbers[start]) {
                    start = mid;
                    // 103, 203, 220, 234, 279, 368
                }
                else {
                    end = mid;
                }
                if (start + 1 == end) {
                    break;
                }
            }

            return start;
        }
    }
}
