using System;

namespace MatrixTrace
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write($"Enter the number of the rows \n>>> ");
                string input = Console.ReadLine();
                int rows = Check.ConsoleInput(input);
                Console.Write($"Enter the number of the columns \n>>> ");
                input = Console.ReadLine();
                int columns = Check.ConsoleInput(input);

                var matrix = new Matrix(rows, columns);
                Console.WriteLine($"Matrix trace: {matrix.Trace()}");
                
                Console.WriteLine("Matrix:");
                Output.Matrix(matrix);

                Console.WriteLine("The snake traversal of the matrix:");
                Console.WriteLine(string.Join(", ", matrix.Snake()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
