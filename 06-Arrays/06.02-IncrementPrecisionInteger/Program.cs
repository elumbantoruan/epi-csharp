using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _06._02_IncrementPrecisionInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> {1,2,4};
            List<int> result = PlusOne(numbers);
            foreach (var item in result) {
                Console.Write($"{item} ");
            }
            Debug.Assert(result.Count == 3);
            Debug.Assert(result[result.Count -1] == 5);
            Console.WriteLine();

            numbers = new List<int> {9,9,9};
            result = PlusOne(numbers);
            foreach (var item in result) {
                Console.Write($"{item} ");
            }
            Debug.Assert(result.Count == 4);
            Debug.Assert(result[result.Count -1] == 0);
        }

        /*
            Time complexity is O(n)
         */
        static List<int> PlusOne(List<int> numbers) {
           
            if (numbers[numbers.Count - 1] < 9) {
                numbers[numbers.Count - 1]++;
                return numbers;
            }

            int endIndex = numbers.Count - 1;
            int sum = 0;
            int carryOver = 0;

            numbers[endIndex] += 1;
            
            while (endIndex >= 0) {
                sum = carryOver + numbers[endIndex];
                numbers[endIndex] = sum % 10;
                carryOver = sum / 10;
                endIndex--;
            }
            if (carryOver > 0) {
                numbers.Insert(0, carryOver);
            }
            
            
            return numbers;
        }
    }
}
