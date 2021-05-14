using System;

namespace MatrixTrace
{
    public class Output
    {
        public static void Matrix(Matrix matrix)
        {
            Check.MatrixInput(matrix);

            int rows = matrix.GetSize(MatrixSize.Rows);
            int columns = matrix.GetSize(MatrixSize.Columns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{matrix[i, j] + " ",3}");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

    }
}
