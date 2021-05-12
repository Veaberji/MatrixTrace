using System;
using System.Collections.Generic;

namespace MatrixTrace
{
    public class Matrix
    {
        public int Rows { get; }
        public int Columns { get; }
        public int[,] Data { get; }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Data = Create(Rows, Columns);
        }

        public static int[,] Create(int rows, int columns)
        {
            Check.RowsAndColumns(rows, columns);

            var rand = new Random();
            var matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rand.Next(101);
                }
            }

            return matrix;
        }

        public static int Trace(int[,] matrix)
        {
            Check.MatrixInput(matrix);

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int sum = 0;
            if (rows == columns)
            {
                for (int i = 0; i < rows; i++)
                {
                    sum += matrix[i, i];
                }
            }
            else
            {
                for (int i = 0, j = 0; i < rows && j < columns; i++, j++)
                {
                    sum += matrix[i, j];
                    if (j == columns - 1)
                    {
                        break;
                    }

                    sum += matrix[i + 1, j];
                    if (i + 1 == rows - 1)
                    {
                        break;
                    }
                }
            }

            return sum;
        }

        public static void Output(int[,] matrix)
        {
            Check.MatrixInput(matrix);

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            bool isBorder = false;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (rows == columns)
                    {
                        if (i == j)
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{matrix[i, j] + " ",3}");
                        Console.ResetColor();
                    }
                    else
                    {
                        if ((i == j || i - 1 == j) && !isBorder)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            if (i == rows - 1 || j == columns - 1)
                                isBorder = true;
                        }

                        Console.Write($"{matrix[i, j] + " ",3}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }

        public static List<int> Snake(int[,] matrix)
        {
            Check.MatrixInput(matrix);

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int length = columns * rows;
            var numbers = new List<int>();
            int lowRow = 0;
            int highRow = rows - 1;
            int lowColumn = 0;
            int highColumn = columns - 1;

            while (numbers.Count < length)
            {

                for (int j = lowColumn; j <= highColumn && lowRow <= highRow; j++)
                    numbers.Add(matrix[lowRow, j]);
                lowRow++;

                for (int i = lowRow; i <= highRow && lowColumn <= highColumn; i++)
                    numbers.Add(matrix[i, highColumn]);
                highColumn--;

                for (int j = highColumn; j >= lowColumn && lowRow <= highRow; j--)
                    numbers.Add(matrix[highRow, j]);
                highRow--;

                for (int i = highRow; i >= lowRow && lowColumn <= highColumn; i--)
                    numbers.Add(matrix[i, lowColumn]);
                lowColumn++;

            }

            return numbers;
        }
    }
}
