using System;
using System.Diagnostics;

namespace _05._08_ReverseDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 42;
            int reversed = ReverseDigits(n);
            Debug.Assert(reversed == 24);

            n = -314;
            reversed = ReverseDigits(n);
            Debug.Assert(reversed == -413);
        }

        /*
            Time complexity is O(n)
            Space complexity is O(1)
         */
        static int ReverseDigits(int n) {
            int signed = 1;
            if (n < 0) {
                signed = -1;
            }
            int result = 0;
            n = Math.Abs(n);
            while (n > 0) {
                result = result * 10 + n % 10;  
                n = n / 10;                     
            }
            return result * signed;
        }
    }
}
