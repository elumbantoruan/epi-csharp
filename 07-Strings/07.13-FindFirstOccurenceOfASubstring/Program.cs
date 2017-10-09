using System;
using System.Diagnostics;

namespace _07._13_FindFirstOccurenceOfASubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            String t = "this is a test text";            
            String s = "test";
            
            int foundIndex = RabinKarp(t, s);
            Console.WriteLine(foundIndex);
            Debug.Assert(foundIndex == 10);
        }

        /*
            Find the first occurrence of a substring
            s = search string
            t = text
         */
        static int RabinKarp(String t, String s) {
            if (s.Length > t.Length) {
                return -1;
            }

            const int BASE = 26;    // 26 is A - Z
            int tHash = 0;
            int sHash = 0;
            int powerS = 1;

            // calculate the power and hash to t and s
            // powerS is used to compute rolling hash later on
            // hash of t and s (tHash and sHash) is an incremental hash function
            // which is an additive function of each individual character
            for (int i = 0; i < s.Length; i++) {
                powerS = i > 0 ? powerS * BASE : 1;
                tHash = tHash * BASE + t[i];
                sHash = sHash * BASE + s[i];
            }

            for (int i = s.Length; i < t.Length; i++) {
                // Checks the two substring are actually equal or not, to protect
                // against hash collition
                if (tHash == sHash && t.Substring(i - s.Length, s.Length).Equals(s)) {
                    return i - s.Length;
                }    

                // uses rolling hash to compute the new hashcode
                tHash = tHash - t[i - s.Length] * powerS;
                tHash = tHash * BASE + t[i];
            }

            if (tHash == sHash && t.Substring(t.Length - s.Length).Equals(s)) {
                return t.Length - s.Length;
            }

            return -1;
        }
    }
}
