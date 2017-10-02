using System;
using System.Diagnostics;

namespace _05._09_CheckIfADecimalIsPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1221;
            bool isPalindrome = IsPalindrome(n);
            Debug.Assert(isPalindrome == true);

            n = 1223;
            isPalindrome = IsPalindrome(n);
            Debug.Assert(isPalindrome == false);
            
        }

        /*
            Time complexity is O(n)
            Space complexity is O(1)
         */
        static bool IsPalindrome(int n) {
            while (n > 0) {
                int numDigits = (int)Math.Log10(n) + 1;                
                int mostSignificantDigit = n / (int)Math.Pow(10, numDigits - 1);
                int leastSignificantDigit = n % 10;
                if (mostSignificantDigit != leastSignificantDigit) {
                    return false;
                }
                n -= mostSignificantDigit * (int)Math.Pow(10, numDigits - 1);   // remove most significant digit
                n /= 10;                                                        // remove least signigicant digit
            }
            
            return true;
        }
    }
}
