using System;
using System.Collections.Generic;
using System.Text;

namespace _07._12_RunLengthEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "aaaabcccaa";
            string encoded = Encoding(s);
            Console.WriteLine(encoded);

            encoded = "3e14f2e";
            string decoded = Decoding(encoded);
            Console.WriteLine(decoded);
        }

        /*
            aaaabcccaa --> 4a1b3c2a
         */
        static string Encoding(string s) {
            StringBuilder sb = new StringBuilder();
            int n = 1;
            for (int i = 1; i < s.Length; i++) {
                if (s[i] == s[i -1]) {
                    n++;
                }
                else {
                    sb.Append(n.ToString());
                    sb.Append(s[i - 1]);
                    n = 1;
                }
            }
            sb.Append(n.ToString());
            sb.Append(s[s.Length - 1]);
            return sb.ToString();
        }

        /*
            3e14f2e  --> eeeffffee
         */
        static string Decoding(string s) {
            StringBuilder sb = new StringBuilder();
            int n = 0;
            for (int i = 0; i < s.Length; i++) {
                if (Char.IsDigit(s[i])) {
                    n = n * 10 + (s[i] - '0');
                }
                else {
                    for (int j = 0; j < n; j++) {
                        sb.Append(s[i]);
                    }
                    n = 0;
                }
            }
            return sb.ToString();
        }
    }
}
