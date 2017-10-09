using System;
using System.Collections.Generic;

namespace _07._05_TestPalindromicity
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "A man, a plan, a canal, Panama.";
            bool isPalindrome = TestPalindrome(s);
            Console.WriteLine(isPalindrome);
        }

        static bool TestPalindrome(String s) {
            
            int start = 0;
            int end = s.Length - 1;
            while (start <= end) {
                if (!Char.IsLetter(s[start])) {
                    start++;
                    continue;
                }
                if (!Char.IsLetter(s[end])) {
                    end--;
                    continue;
                }
                if (Char.ToLower(s[start]) != Char.ToLower(s[end])) {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }
    }
}
