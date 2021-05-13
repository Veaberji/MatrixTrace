using MatrixTrace;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
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

            int result = matrix.GetSize(0);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetSize_OneAsDimension_ReturnTheNumberOfTheColumns()
        {
            var matrix = new Matrix(2, 3);
            int expected = 3;

            int result = matrix.GetSize(1);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetSize_TwoAsDimension_TrowArgumentOutOfRangeException()
        {
            var matrix = new Matrix(2, 3);
            int expected = 2;

            int result = matrix.GetSize(3);

            Assert.That(() => matrix.GetSize(3), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void FillMatrix_3Rows4Columns_ReturnFullMatrix3x4()
        {
            int rows = 3;
            int columns = 4;

            var result = new Matrix(rows, columns);
            bool isFull = result.ToString().Any(n => n > 0);

            Assert.That(result.GetSize(0), Is.EqualTo(3));
            Assert.That(result.GetSize(1), Is.EqualTo(4));
            Assert.That(isFull, Is.True);
        }

        [Test] //doesn`t work, I don`t why)
        public void Trace_4x4Matrix_ReturnTheSumOfTheNumbersOfTheMainDiagonal()
        {

            var mock = new Mock<IMatrix>();
            mock.Setup(matrix => matrix.FillMatrix()).Returns(new int[4, 4]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16},
            });
            int expected = 34;


            int result = mock.Object.Trace();

            Assert.That(result, Is.EqualTo(expected));
        }


    }
}
