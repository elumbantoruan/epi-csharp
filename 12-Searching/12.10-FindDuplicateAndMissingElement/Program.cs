using System;
using System.Collections.Generic;

namespace _12._10_FindDuplicateAndMissingElement
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 5, 3, 0, 3, 1, 2 };
            var result = FindDuplicateAndMissing(numbers);
            Console.WriteLine($"Duplicate: {result.Duplicate}");
            Console.WriteLine($"Missing: {result.Missing}");

            result = FindDupMissing(numbers);
            Console.WriteLine(result.Duplicate);
        }

        static DuplicateAndMissing FindDupMissing(List<int> numbers) {
            int duplicate = 0;
            int total = 0;
            int max = 0;
            for (int i = 0; i < numbers.Count; i++) {
                total += numbers[i];
                max = Math.Max(max, numbers[i]);
            }
            double triangularSeries = (max * max + max) / 2;
            duplicate = (int) Math.Abs(triangularSeries - total);

            return new DuplicateAndMissing(duplicate, 0);
        }

        static DuplicateAndMissing FindDuplicateAndMissing(List<int> numbers)
        {
            // compute the XOR of all numbers from 0 to |number| -1 and all entries in numbers
            int missXORDup = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                missXORDup ^= i ^ numbers[i];
            }

            // we need to find a bit that's set to 1 in missXORDup.  Such a bit
            // must exist if there is a single missing number and a single duplicated
            // number
            // The bit-fiddling assignment below sets all of bits in differBit to 0
            // except for the least significant bit in missXORDup that's 1
            int differBit = missXORDup & (~(missXORDup - 1));
            int missOrDup = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                // focus on entries and numbers in which the differBit -th bit is 1
                if ((i & differBit) != 0)
                {
                    missOrDup ^= i;
                }
                if ((numbers[i] & differBit) != 0)
                {
                    missOrDup ^= numbers[i];
                }
            }

            // missOrDup is either the missing value or the duplicated entry
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == missOrDup)
                {
                    return new DuplicateAndMissing(missOrDup, missOrDup ^ missXORDup);
                }
            }
            // missOrDup is the missing value
            return new DuplicateAndMissing(missOrDup ^ missXORDup, missOrDup);
        }
    }

    public class DuplicateAndMissing
    {
        public int Duplicate { get; set; }
        public int Missing { get; set; }

        public DuplicateAndMissing(int duplicate, int missing)
        {
            Duplicate = duplicate;
            Missing = missing;
        }
    }
}
