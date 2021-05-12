using NUnit.Framework;

namespace MatrixTraceTests
{
    [TestFixture]
    class СheckTests
    {
        [Test]
        public void Input_InputNotANumber_ThrowArgumentException()
        {
            string input = "abc";

            Assert.That(() => MatrixTrace.Check.ConsoleInput(input), Throws.ArgumentException);
        }
        [Test]
        public void Input_InputIsANumber_ReturnInputAsInteger()
        {
            string input = " 5 ";
            int expected = 5;

            int result = MatrixTrace.Check.ConsoleInput(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RowsAndColumns_RowsLessThan2_ThrowArgumentException()
        {
            int rows = 1;
            int columns = 2;

            Assert.That(() => MatrixTrace.Check.RowsAndColumns(rows, columns), Throws.ArgumentException);
        }

        [Test]
        public void RowsAndColumns_ColumnsLessThan2_ThrowArgumentException()
        {
            int rows = 2;
            int columns = 1;

            Assert.That(() => MatrixTrace.Check.RowsAndColumns(rows, columns), Throws.ArgumentException);
        }


        [Test]
        public void MatrixInput_ArgumentIsNull_ThrowArgumentException()
        {
            int[,] matrix = null;

            Assert.That(() => MatrixTrace.Check.MatrixInput(matrix), Throws.ArgumentNullException);
        }

        [Test]
        public void MatrixInput_RowsLessThan2_ThrowArgumentException()
        {
            int[,] matrix =
            {
                {1, 2, 3}
            };

            Assert.That(() => MatrixTrace.Check.MatrixInput(matrix), Throws.ArgumentException);
        }

        [Test]
        public void MatrixInput_ColumnsLessThan2_ThrowArgumentException()
        {
            int[,] matrix =
            {
                {1},
                {2},
                {3},
            };

            Assert.That(() => MatrixTrace.Check.MatrixInput(matrix), Throws.ArgumentException);
        }
    }
}
