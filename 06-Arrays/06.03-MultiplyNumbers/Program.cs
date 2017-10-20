using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _06._03_MultiplyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> n1 = new List<int> { 2, 5};
            List<int> n2 = new List<int> { 3 };
            List<int> results = Multiply(n1, n2);
            foreach (var item in results)
            {
                Console.Write($"{item} ");
            }
            List<int> expected = new List<int> {7,5};
            for (int i = 0; i < results.Count; i++)
            {
                Debug.Assert(results[i] == expected[i]);
            }
            Console.WriteLine();
            n1 = new List<int> { -2, 5};
            n2 = new List<int> { 3 };
            results = Multiply(n1, n2);
            foreach (var item in results)
            {
                Console.Write($"{item} ");
            }
            expected = new List<int> {-7,5};
            for (int i = 0; i < results.Count; i++)
            {
                Debug.Assert(results[i] == expected[i]);
            }
            Console.WriteLine();
            n1 = new List<int> { -2, 5};
            n2 = new List<int> { -2, 5 };
            results = Multiply(n1, n2);
            foreach (var item in results)
            {
                Console.Write($"{item} ");
            }
            expected = new List<int> {6,2,5};
            for (int i = 0; i < results.Count; i++)
            {
                Debug.Assert(results[i] == expected[i]);
            }
        }

        /*
            Time complexity O(nm) where n is n1 elements and m is n2 elements
            Not O(n^2) because it's not the same list elements
         */
        static List<int> Multiply(List<int> n1, List<int> n2) {
            int signed = 1;
            if (n1[0] * n2[0] < 0) {
                signed = -1;
            }
            int[] arr = new int[n1.Count + n2.Count];
            List<int> results = new List<int>(arr);
            int result = 0;
            int carryOver = 0;
            for (int i = n1.Count - 1; i >= 0; i--) {
                for (int j = n2.Count - 1; j >=0; j--) {
                    result = Math.Abs(n1[i] * n2[j]) + carryOver;
                    results[i + j + 1] += result % 10;
                    carryOver = result / 10;

                    if (carryOver > 0) {
                        results[i + j] += carryOver;
                        carryOver = 0;
                    }
                }
            }

            if (results[0] == 0)
            {
                results.RemoveAt(0);
            }

            results[0] *= signed;
            return results;
        }
    }
}
