using System;
using System.Collections.Generic;

namespace _06._09_PermuteElementsOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> {1,2,3,4};
            int n = CountNumberOfPerms(numbers.Count);
            List<int> perm = CreateEmptyList(n);
            ApplyPermutations(perm, numbers);
            foreach (var item in perm)
            {
                Console.Write($"{item} ");
            }
        }

        static int CountNumberOfPerms(int n) {
            int count = 1;
            while (n > 0) {
                count *= n;
                n--;
            }
            return count;
        }

        static void ApplyPermutations(List<int> perm, List<int> numbers) {
            for (int i = 0; i < numbers.Count; i++) {
                // check if the element at index i has not been moved by checking if
                // perm.Count is nonnegative
                int next = i;
                while (perm[next] >= 0) {
                    Swap(numbers, i, perm[next]);
                    int temp = perm[next];
                    // subtracts perm.Count from an entry in perm to make it negative,
                    // which indicates the corresponding move has been performed
                    perm[next] = perm[next] - perm.Count;
                    next = temp;
                }
            }

            // restore the perm
            for (int i = 0; i < perm.Count; i++) {
                perm[i] = perm[i] + perm.Count;
            }
        }

        static void Swap(List<int> list, int i, int j) {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        static List<int> CreateEmptyList(int n) {
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++) {
                list.Add(0);
            }
            return list;
        }
    }
}
