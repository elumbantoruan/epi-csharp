using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _06._17_SpiralOrder2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> matrix = new List<List<int>> {
                new List<int> {1,2,3,4},
                new List<int> {5,6,7,8},
                new List<int> {9,10,11,12},
                new List<int> {13,14,15,16}
            };

            List<int> spiral = MatrixInSpiralOrder(matrix);
            List<int> expected = new List<int> { 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10 };

            for (int i = 0; i < spiral.Count; i++) {
                Debug.Assert(spiral[i] == expected[i]);
            }

            for (int i =0 ; i < spiral.Count; i++) {
                Console.Write($"{spiral[i]} ");
            }
            Console.WriteLine();
        }

        static List<int> MatrixInSpiralOrder(List<List<int>> matrix) {
            List<int> spiral = new List<int>();
            int rowStart = 0;
            int rowEnd = matrix.Count - 1;
            int colStart = 0;
            int colEnd = matrix[0].Count - 1;

            while (rowStart < rowEnd && colStart < colEnd) {

                for (int i = colStart; i <= colEnd; i++)  {
                    spiral.Add(matrix[rowStart][i]);
                }

                for (int i = rowStart + 1; i <= rowEnd; i++) {
                    spiral.Add(matrix[i][colEnd]);
                }

                for (int i = colEnd - 1; i > colStart; i--) {
                    spiral.Add(matrix[rowEnd][i]);
                }

                for (int i = rowEnd; i > rowStart; i--) {
                    spiral.Add(matrix[i][colStart]);
                }

                colStart++;
                colEnd--;
                rowStart++;
                rowEnd--;
            }

            return spiral;
        }
    }
}
