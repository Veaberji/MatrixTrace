using MatrixTrace;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MatrixTraceTests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void Create_3Rows4Columns_ReturnFullMatrix3x4()
        {
            int rows = 3;
            int columns = 4;

            var result = Matrix.Create(rows, columns);
            bool isFull = result.ToString().Any(n => n > 0);

            Assert.That(result.GetLength(0), Is.EqualTo(3));
            Assert.That(result.GetLength(1), Is.EqualTo(4));
            Assert.That(isFull, Is.True);
        }

        [Test]
        public void Trace_4x4Matrix_ReturnTheSumOfTheNumbersOfTheMainDiagonal()
        {
            var matrix = new int[4, 4]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16},
            };
            int expected = 34;

            int result = Matrix.Trace(matrix);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Trace_3x4Matrix_ReturnTheSumOfTheNumbersOfTheMainDiagonal()
        {
            var matrix = new int[3, 4]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
            };
            int expected = 18;

            int result = Matrix.Trace(matrix);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Trace_4x3Matrix_ReturnTheSumOfTheNumbersOfTheMainDiagonal()
        {
            var matrix = new int[4, 3]
            {
                {1, 2, 3},
                {5, 6, 7},
                {9, 10, 11},
                {13, 14, 15},
            };
            int expected = 18;

            int result = Matrix.Trace(matrix);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Snake_4x3Matrix_NumbersInAClockwiseSpiral()
        {
            var matrix = new int[4, 3]
            {
                {1, 2, 3},
                {5, 6, 7},
                {9, 10, 11},
                {13, 14, 15},
            };
            var expected = new List<int> { 1, 2, 3, 7, 11, 15, 14, 13, 9, 5, 6, 10 };

            var result = Matrix.Snake(matrix);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Snake_3x4Matrix_NumbersInAClockwiseSpiral()
        {
            var matrix = new int[3, 4]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
            };
            var expected = new List<int> { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 };

            var result = Matrix.Snake(matrix);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
