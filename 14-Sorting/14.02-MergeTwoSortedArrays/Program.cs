using System;

namespace _14._02_MergeTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] l1 = { 5, 13, 17, 0, 0, 0, 0, 0 };
            int[] l2 = { 3, 7, 11, 19 };
            int m = 3;
            int n = 4;
            Merge(l1, m, l2, n);
            Console.WriteLine();
            for (int i = 0; i < l1.Length; i++)
            {
                Console.Write($"{l1[i]} ");
            }
        }

        static void Merge(int[] l1, int m, int[] l2, int n)
        {
            int mIndex = m - 1;
            int nIndex = n - 1;
            int mergedIndex = m + n - 1;

            while (mIndex >= 0 && nIndex >= 0) {
                if (l1[mIndex] > l2[nIndex]) {
                    l1[mergedIndex--] = l1[mIndex--];
                }
                else {  // l1 < l2
                    l1[mergedIndex--] = l2[nIndex--];
                }
            }

            while (nIndex >= 0) {
                l1[mergedIndex--] = l2[nIndex--];
            }
        }
    }
}
