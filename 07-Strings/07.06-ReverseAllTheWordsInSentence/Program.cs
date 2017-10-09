using System;
using System.Collections.Generic;

namespace _07._06_ReverseAllTheWordsInSentence
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello World!";
            string reversed = ReverseWords(s);
            Console.WriteLine(reversed);
        }

        static string ReverseWords(String s) {
            char[] chars = s.ToCharArray();
            ReverseChars(0, chars.Length - 1, chars);
            int start = 0;
            for (int i = 0; i < chars.Length; i++) {
                if (chars[i] == ' ') {
                    ReverseChars(start, i - 1, chars);
                    start = i + 1;
                }
                else if (i == chars.Length - 1) {
                    ReverseChars(start, i, chars);
                }
            }
            return new string(chars);
        }

        static void ReverseChars(int start, int end, char[] chars) {
            while (start < end) {
                char temp = chars[start];
                chars[start] = chars[end];
                chars[end] = temp;
                start++;
                end--;
            }
        }
    }
}
