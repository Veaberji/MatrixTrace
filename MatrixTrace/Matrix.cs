using System;
using System.Collections.Generic;

namespace MatrixTrace
{
    public class Matrix : IMatrix
    {
        private int _rows { get; }
        private int _columns { get; }
        private int[,] _data { get; }

        public int this[int index1, int index2] => _data[index1, index2];

        public Matrix(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _data = FillMatrix();
        }

        public Matrix(int[,] array)
        {
            Check.ArrayInput(array);
            _rows = array.GetLength(0);
            _columns = array.GetLength(1);
            Check.RowsAndColumns(_rows, _columns);
            _data = array;
        }

        public int GetSize(MatrixSize size)
        {
            switch (size)
            {
                case MatrixSize.Rows:
                    return _rows;
                case MatrixSize.Columns:
                    return _columns;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        public int[,] FillMatrix()
        {
            Check.RowsAndColumns(_rows, _columns);

            var rand = new Random();
            var matrix = new int[_rows, _columns];

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    matrix[i, j] = rand.Next(101);
                }
            }

            return matrix;
        }

        public int Trace()
        {

            int minDimension = Math.Min(_rows, _columns);
            int sum = 0;

            for (int i = 0; i < minDimension; i++)
                sum += _data[i, i];

            return sum;
        }

        public List<int> Snake()
        {

            int length = _rows * _columns;
            int lowRow = 0;
            int highRow = _rows - 1;
            int lowColumn = 0;
            int highColumn = _columns - 1;
            var numbers = new List<int>();

            while (numbers.Count < length)
            {

                for (int j = lowColumn; j <= highColumn && lowRow <= highRow; j++)
                    numbers.Add(_data[lowRow, j]);
                lowRow++;

                for (int i = lowRow; i <= highRow && lowColumn <= highColumn; i++)
                    numbers.Add(_data[i, highColumn]);
                highColumn--;

                for (int j = highColumn; j >= lowColumn && lowRow <= highRow; j--)
                    numbers.Add(_data[highRow, j]);
                highRow--;

                for (int i = highRow; i >= lowRow && lowColumn <= highColumn; i--)
                    numbers.Add(_data[i, lowColumn]);
                lowColumn++;

            }

            return numbers;
        }
    }
}
