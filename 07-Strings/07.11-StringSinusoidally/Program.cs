using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _07._11_StringSinusoidally
{
    class Program
    {
        /*
                e               _               l
            H       l       o       W       r       d
                        l               o               !
                    
         */
        static void Main(string[] args)
        {
            string s = "Hello World!";
            string ss = SnakeString(s);
            Console.WriteLine(ss);
            Debug.Assert(ss.StartsWith("e"));
        }

        static string SnakeString(String s) {
            List<Char> line1 = new List<Char>();
            List<Char> line2 = new List<Char>();
            List<Char> line3 = new List<Char>();

            for (int i = 1; i < s.Length; i += 4) {
                line1.Add(s[i]);
            }

            for (int i = 0; i < s.Length; i += 2) {
                line2.Add(s[i]);
            }

            for (int i = 3; i < s.Length; i += 4) {
                line3.Add(s[i]);
            }

            string result = new string(line1.ToArray());
            result += new string(line2.ToArray());
            result += new string(line3.ToArray());

            return result;
        }


    }
}
