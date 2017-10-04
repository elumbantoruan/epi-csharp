using System;
using System.Collections.Generic;

namespace _06._19_ComputeRowsPascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            List<List<int>> rows = GeneratePascalTriangle(n);
            foreach (var row in rows)
            {
                foreach (var item in row)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }

        static List<List<int>> GeneratePascalTriangle(int numRows) {
            List<List<int>> rows = new List<List<int>>();
            for (int i = 0; i < numRows; i++) {
                List<int> row = new List<int>();
                for (int j = 0; j <= i; j++ ) {
                    if (j == 0 || j == i) {
                        row.Add(1);
                    }
                    else {
                        int value = rows[i - 1][j - 1] + rows[i - 1][j];
                        row.Add(value);
                    }
                }
                rows.Add(row);
            }
            return rows;
        }
    }
}
