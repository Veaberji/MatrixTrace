using System;

namespace MatrixTrace
{
    public class Check
    {
        public static int ConsoleInput(string input)
        {
            bool isInputNumber = int.TryParse(input, out int number);
            if (!isInputNumber || number < 1)
            {
                throw new ArgumentException($"Error: 'Input' must be a number not less than 1");
            }

            return number;
        }

        public static void RowsAndColumns(int rows, int columns)
        {
            if (rows < 1 || columns < 1)
                throw new ArgumentException(
                    $"Error: 'rows and columns' must be the numbers not less than 1");
        }

        public static void MatrixInput(IMatrix matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("Error: 'matrix' can`t be null");
        }

        public static void ArrayInput(int[,] array)
        {
            if (array == null)
                throw new ArgumentNullException("Error: 'array' can`t be null");
        }
    }
}