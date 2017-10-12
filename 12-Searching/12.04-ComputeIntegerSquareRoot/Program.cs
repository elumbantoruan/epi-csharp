using System;

namespace _12._04_ComputeIntegerSquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 16;
            int result = ComputeSquareRoot(n);
            Console.WriteLine(result);
        }

        static int ComputeSquareRoot(int n) {
            int start = 0;
            int end = n;

            while (start <= end) {
                int mid = start + (end - start) / 2;
                int square = mid * mid;
                if (square <= n) {
                    start = mid + 1;
                }
                else {
                    end = mid - 1;
                }
            }
            return start - 1;
        }
    }
}
