using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _07._09_RomanToDecimal
{
    class Program
    {
        static Dictionary<Char,int> mapper = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}            
        };
        static void Main(string[] args)
        {
            string s = "LIX";
            int result = RomanToDecimal(s);
            Console.WriteLine(result);
            Debug.Assert(result == 59);

            s = "XXXXXIIIIIIIII";
            result = RomanToDecimal(s);
            Console.WriteLine(result);
            Debug.Assert(result == 59);
        }

        static int RomanToDecimal(string s) {
            int result = 0;
            for (int i = s.Length - 1; i >= 0; i--) {
                if (i == s.Length - 1) {
                    result = mapper[s[i]];
                }
                else if (mapper[s[i]] < mapper[s[i + 1]]) {
                    result -= mapper[s[i]];
                }
                else {
                    result += mapper[s[i]];
                }
            }
            return result;
        }
    }
}
