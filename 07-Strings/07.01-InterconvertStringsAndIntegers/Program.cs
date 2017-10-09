using System;

namespace _07._01_InterconvertStringsAndIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 123;
            string s = IntToString(n);
            Console.WriteLine(s);
            int result = StringToInteger(s);
            Console.WriteLine(result);
        }

        static string IntToString(int n) {
            int numOfDigits = (int)Math.Floor(Math.Log10(n) + 1);
            char[] chars = new char[numOfDigits];
            int charIndex = numOfDigits - 1;
            while (n > 0) {
                chars[charIndex --] = (char) (n % 10 + '0');
                n /= 10; 
            }
            return new string(chars);
        }

        static int StringToInteger(String s) {
            int result = 0;
            for (int i = 0; i < s.Length; i++) {
                result = result * 10 + s[i] - '0';
            }
            return result;
        }
    }
}
