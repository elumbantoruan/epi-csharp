using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _07._07_MnemonicsPhoneNumber
{
    class Program
    {
        static Dictionary<Char, string> keyPad = new Dictionary<Char, string> {
            {'0', "0" }, 
            {'1', "1" }, 
            {'2', "ABC"}, 
            {'3', "DEF"}, 
            {'4', "GHI"}, 
            {'5', "JKL"}, 
            {'6', "MNO"}, 
            {'7', "PQRS"}, 
            {'8', "TUV"}, 
            {'9', "WXYZ"}
        };

        static void Main(string[] args)
        {
            string number = "2276696";
            List<string> mnemonics = MnemonicsPhoneNumber(number);
            Console.WriteLine($"Contains ACRONYM: {mnemonics.Contains("ACRONYM")}");
            Debug.Assert(mnemonics.Contains("ACRONYM"));
        }

        static List<String> MnemonicsPhoneNumber(String number) {
            List<String> mnemonics = new List<String>();
            MnemonicsPhoneNumber(number, 0, new char[number.Length], mnemonics);
            return mnemonics;
        }

        static void MnemonicsPhoneNumber(String number, int digit, char[] partialMnemonics, List<String> mnemonics) {
            if (digit == number.Length) {
                mnemonics.Add(new string(partialMnemonics));
            }
            else {
                foreach (Char c in keyPad[number[digit]])
                {
                    partialMnemonics[digit] = c;
                    MnemonicsPhoneNumber(number, digit + 1, partialMnemonics, mnemonics);
                }
            }
        }
    }
}
