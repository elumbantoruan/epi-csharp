using System;

namespace _07._03_ComputeColumnEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "ZZ";
            int decoded = DecodeColumn(s);
            Console.WriteLine(decoded);
        }

        /*
            DecodeColumn transform A to 1, D to 4, Z 26
            (A-Z) 1 - 26
            ZZ 702
            Time complexity: O(n)
         */
        static int DecodeColumn(String s) {
            int result = 0;
            for (int i = 0; i < s.Length; i++) {
                result = result * 26 + s[i] - 'A' + 1;
            }
            return result;
        }
    }
}
