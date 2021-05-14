using MatrixTrace;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixTraceTests
{
    [TestFixture]
    public class MatrixTests
    {

        [Test]
        public void GetSize_ZeroAsDimension_ReturnTheNumberOfTheRows()
        {
            var matrix = new Matrix(2, 3);
            int expected = 2;

            int result = matrix.GetSize(MatrixSize.Rows);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetSize_OneAsDimension_ReturnTheNumberOfTheColumns()
        {
            var matrix = new Matrix(2, 3);
            int expected = 3;

            int result = matrix.GetSize(MatrixSize.Columns);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetSize_TwoAsDimension_TrowArgumentOutOfRangeException()
        {
            var matrix = new Matrix(2, 3);
            int size = 3;

            Assert.That(() => matrix.GetSize((MatrixSize)size),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void FillMatrix_3Rows4Columns_ReturnFullMatrix3x4()
        {
            int rows = 3;
            int columns = 4;

            var result = new Matrix(rows, columns);
            bool isFull = result.ToString().Any(n => n > 0);

            Assert.That(result.GetSize(MatrixSize.Rows), Is.EqualTo(3));
            Assert.That(result.GetSize(MatrixSize.Columns), Is.EqualTo(4));
            Assert.That(isFull, Is.True);
        }

        [Test]
        public void Trace_4x4Matrix_ReturnTheSumOfTheNumbersOfTheMainDiagonal()
        {

            var mock = new Mock<IMatrix>();
            var matrix = new int[4, 4]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16},
            };
            int expected = 34;


            var result = new Matrix(matrix).Trace();

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

            int result = new Matrix(matrix).Trace();

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

            int result = new Matrix(matrix).Trace();

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

            var result = new Matrix(matrix).Snake();

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

            var result = new Matrix(matrix).Snake();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
