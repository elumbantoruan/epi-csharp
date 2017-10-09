using System;

namespace _07._04_ReplaceAndRemove
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] chars = {'a','c', 'd', 'b', 'b', 'c', 'a'};
            Console.WriteLine($"Input: {new string(chars)}");
            ReplaceAndRemove(7, chars);
            Console.WriteLine($"Output: {new string(chars)}");
        }

        /*
            Replace each 'a' by two 'd's.
            Delete each entry containing a 'b'
            test input =  { 'a','c','d','b','b','c','a'}
            test output = { 'd','d','c','d','c','d','d'}
        */
        static void ReplaceAndRemove(int size, Char[] chars) {
            int writeIndex = 0;
            int aCount = 0;
            for (int i = 0; i < size; i++) {
                if (chars[i] != 'b') {
                    chars[writeIndex++] = chars[i];
                }
                if (chars[i] == 'a') {
                    aCount++;
                }
            }
            /* 'a','c','d','c','a */
            int currentIndex = writeIndex - 1;
            writeIndex = writeIndex + aCount - 1;
            while (currentIndex >= 0) {
                if (chars[currentIndex] == 'a') {
                    chars[writeIndex --] = 'd';
                    chars[writeIndex --] = 'd';
                }
                else {
                    chars[writeIndex--] = chars[currentIndex];
                }
                currentIndex--;
            }
        }
    }
}
