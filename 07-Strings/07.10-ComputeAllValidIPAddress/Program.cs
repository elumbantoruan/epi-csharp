using System;
using System.Collections.Generic;

namespace _07._10_ComputeAllValidIPAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = "19216811";
            //s = "255255111";
            //s = "255255255255";
            List<String> ipAddress = GetAllValidIPAddress(s);
            foreach (var item in ipAddress)
            {
                Console.WriteLine($"{item} ");
            }
        }

        static List<string> GetAllValidIPAddress(String s) {
            if (s.Length == 0 || s.Length < 4 || s.Length > 12) {
                throw new ArgumentException("Not a valid length");
            }
            List<string> results = new List<string>();
            for (int i = 1; i < s.Length && i < 4; i++) {
                string first = s.Substring(0, i);
                if (IsValidPart(first)) {
                    for (int j = 1; j < s.Length && j < 4; j++) {
                        string second = s.Substring(i, j);
                        if (IsValidPart(second)) {
                            for (int k = 1; k < s.Length && k < 4; k++) {
                                if (i + j + k < s.Length) {
                                    string third = s.Substring(i + j, k);
                                    // 19216811
                                    string forth = s.Substring(i + j + k);
                                    if (IsValidPart(third) && IsValidPart(forth)) {
                                        results.Add(first + "." + second + "." + third + "." + forth);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return results;
        }

        static bool IsValidPart(String s) {
            if (s.Length == 0 || s.Length > 3) {
                return false;
            }
            if (s[0] == '0' && s.Length > 1) {
                return false;
            }

            int val = Int32.Parse(s);
            if (val > 255) {
                return false;
            }
            return true;
        }

    }
}
