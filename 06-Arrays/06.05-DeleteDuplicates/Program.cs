using System;
using System.Collections.Generic;

namespace _06._05_DeleteDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>
            {
                2,3,5,5,7,11,11,11,13
            };
            int result = DeleteDuplicates(numbers);
            Console.WriteLine(result);
            foreach (var item in numbers)
            {
                Console.Write($"{item} ");
            }
        }

        /*
            Input:  [2,3,5,5, 7,11,11,11,13]
            Output: [2,3,5,7,11,13, 0, 0, 0]

            [2,2,3]
            [2,3,0]

            Time complexity: O(n)
            Space complexity: O(1)
         */
        static int DeleteDuplicates(List<int> numbers) {
            int index = 1;
            
            for (int i = 1; i < numbers.Count; i++) {
                if (numbers[i] != numbers[i - 1]) {
                    numbers[index++] = numbers[i];
                }
            }
            for (int i = index; i < numbers.Count; i++) {
                numbers[i] = 0;
            }
            return index;
        }
    }
}
