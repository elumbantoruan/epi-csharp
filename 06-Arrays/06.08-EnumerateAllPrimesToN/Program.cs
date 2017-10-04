using System;
using System.Collections.Generic;

namespace _06._08_EnumerateAllPrimesToN
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> results = AllPrimes(18);
            foreach (var item in results)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        static List<int> AllPrimes(int n) {
            List<int> results = new List<int>();
            bool[] primeFlags = InitializePrimesFlag(n);
            for (int i = 2; i <= n; i++) {
                if (primeFlags[i]) {
                    results.Add(i);
                }
                /*
                    2, 4; 3, 6; 4; 8
                 */
                for (int j = i; j <= n; j+= i) {
                    primeFlags[j] = false;
                }
            }
            return results;
        }

        static bool[] InitializePrimesFlag(int n) {
            bool[] flags = new bool[n + 1];
            for (int i = 2; i < flags.Length; i++) {
                flags[i] = true;
            }
            return flags;
        }
    }
}
