using System;
using System.Collections.Generic;

namespace _12._06_SearchIn2DSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> row0 = new List<int> {-1, 2, 4, 4, 6};
            List<int> row1 = new List<int> {1, 5, 5, 9, 21};
            List<int> row2 = new List<int> {3, 6, 6, 9, 22};
            List<int> row3 = new List<int> {3, 6, 8, 10, 24};
            List<int> row4 = new List<int> {6, 8, 9, 12, 25};
            List<int> row5 = new List<int> {8, 10, 12, 13, 40};

            List<List<int>> matrix = new List<List<int>> { row0, row1, row2, row3, row4, row5};
            int n = 10;
            bool found = SearchIn2DSortedArray(matrix, n);
            Console.WriteLine(found);            
            

        }

        /*
            Time complexity: O(mn) where m is the number of rows and n is columns
         */
        static bool SearchIn2DSortedArray(List<List<int>> matrix, int n) {
            int row = 0;
            int col = matrix[0].Count - 1;
            while (row < matrix.Count && col >= 0) {
                if (matrix[row][col] == n) {
                    return true;
                }
                else if (matrix[row][col] < n) {
                    row++;
                }
                else {
                    col--;
                }
            }
            return false;
        }
    }
}
