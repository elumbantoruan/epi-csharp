using System;
using System.Collections.Generic;

namespace _06._18_RotateMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> matrix = new List<List<int>>();
            List<int> row1 = new List<int> { 1, 2, 3, 4 };
            List<int> row2 = new List<int> { 5, 6, 7, 8 };
            List<int> row3 = new List<int> { 9, 10, 11, 12 };
            List<int> row4 = new List<int> { 13, 14, 15, 16 };
            matrix.Add(row1);
            matrix.Add(row2);
            matrix.Add(row3);
            matrix.Add(row4);

            RotateMatrix(matrix);

            foreach (var items in matrix)
            {
                foreach (var item in items)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }

        /*
         *  1  2  3  4          13  9  5  1
         *  5  6  7  8          14 10  6  2
         *  9 10 11 12          15 11  7  3
         * 13 14 15 16          16 12  8  4
         */
         // Time complexity: O(n)
         // Space complexity: O(1)
         // Note:   the array element in outer loop is only iterated half way
         //         because it's only needed into its way to the center of the array
         //         from the outermost layers
         //         When iterating the elements of square matrix rotate the index of i and j
         //         back and forth.
         //         If it starts with i for the row and j for the column
         //         then rotate the next iteration with j for the row and i for the column
        static void RotateMatrix(List<List<int>> squareMatrix) {
            int matrixSize = squareMatrix.Count - 1;
            for (int i = 0; i < squareMatrix.Count / 2; i++) {  
                for (int j = i; j < matrixSize - i; j++) {
                    /* This is also work if we use j for the first row and i for column  */ 
                    // int temp1 = squareMatrix[matrixSize - j][i];
                    // int temp2 = squareMatrix[matrixSize - i][matrixSize - j];
                    // int temp3 = squareMatrix[j][matrixSize - i];
                    // int temp4 = squareMatrix[i][j];

                    // squareMatrix[i][j] = temp1;
                    // squareMatrix[matrixSize - j][i] = temp2;
                    // squareMatrix[matrixSize - i][matrixSize - j] = temp3;
                    // squareMatrix[j][matrixSize - i] = temp4;

                    int temp1 = squareMatrix[matrixSize - i][j];
                    int temp2 = squareMatrix[matrixSize - j][matrixSize - i];
                    int temp3 = squareMatrix[i][matrixSize - j];
                    int temp4 = squareMatrix[j][i];

                    squareMatrix[j][i] = temp1;
                    squareMatrix[matrixSize - i][j] = temp2;
                    squareMatrix[matrixSize - j][matrixSize - i] = temp3;
                    squareMatrix[i][matrixSize - j] = temp4;


                }
            }
        }
    }
}
