using System;
using System.Collections.Generic;

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
            Console.WriteLine();
            n1 = new List<int> { -2, 5};
            n2 = new List<int> { 3 };
            results = Multiply(n1, n2);
            foreach (var item in results)
            {
                Console.Write($"{item} ");
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
            List<int> results = new List<int>();
            int result = 0;
            int carryOver = 0;
            for (int i = n1.Count - 1; i >= 0; i--) {
                for (int j = n2.Count - 1; j >=0; j--) {
                    result = Math.Abs(n1[i] * n2[j]) + carryOver;
                    results.Insert(0, result % 10);
                    carryOver = result / 10;
                }
            }
            if (carryOver > 0) {
                results.Insert(0, carryOver);
            }
            results[0] *= signed;
            return results;
        }
    }
}
