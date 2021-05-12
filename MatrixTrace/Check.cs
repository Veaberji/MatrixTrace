using System;

namespace MatrixTrace
{
    public class Check
    {
        public static int ConsoleInput(string input)
        {
            bool isInputNumber = int.TryParse(input, out int number);
            if (!isInputNumber || number < 2)
            {
                throw new ArgumentException($"Error: 'Input' must be a number not less than 2");
            }

            return number;
        }

        public static void RowsAndColumns(int rows, int columns)
        {
            if (rows < 2 || columns < 2)
                throw new ArgumentException(
                    $"Error: 'rows and columns' must be the numbers not less than 2");
        }

        public static void MatrixInput(int[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("'matrix' can`t be null");

            if (matrix.GetLength(0) < 2 || matrix.GetLength(1) < 2)
                throw new ArgumentException($"Error: 'matrix' must be at least 2×2");
        }
    }
}