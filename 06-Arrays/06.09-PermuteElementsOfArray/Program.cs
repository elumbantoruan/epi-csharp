using System;
using System.Collections.Generic;

namespace _06._09_PermuteElementsOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {1,2,3,4};
            IList<IList<int>> results = Permute(numbers);
            foreach (var result in results) {
                foreach (var item in result)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }

        static IList<IList<int>> Permute(int[] nums) {
            IList<IList<int>> results = new List<IList<int>>();
            Permute(results, nums, 0);
            return results;
        }

        static void Permute(IList<IList<int>> results, int[] nums, int start) {
            if (start >= nums.Length) {
                List<int> current = new List<int>();
                for (int i = 0; i < nums.Length; i++) {
                    current.Add(nums[i]);
                }
                results.Add(current);
            }

            for (int i = start; i < nums.Length; i++) {
                Swap(nums, start, i);
                Permute(results, nums, start + 1);
                Swap(nums, start, i);
            }
        }

        static void Swap(int[] list, int i, int j) {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
