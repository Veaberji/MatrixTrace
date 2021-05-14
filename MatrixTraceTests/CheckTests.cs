using NUnit.Framework;

namespace MatrixTraceTests
{
    [TestFixture]
    class CheckTests
    {
        [Test]
        public void ConsoleInput_InputNotANumber_ThrowArgumentException()
        {
            string input = "abc";

            Assert.That(() => MatrixTrace.Check.ConsoleInput(input), Throws.ArgumentException);
        }

        [Test]
        public void ConsoleInput_InputIsANumber_ReturnInputAsInteger()
        {
            string input = " 5 ";
            int expected = 5;

            int result = MatrixTrace.Check.ConsoleInput(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RowsAndColumns_RowsLessThan1_ThrowArgumentException()
        {
            int rows = 0;
            int columns = 2;

            Assert.That(() => MatrixTrace.Check.RowsAndColumns(rows, columns), Throws.ArgumentException);
        }

        [Test]
        public void RowsAndColumns_ColumnsLessThan1_ThrowArgumentException()
        {
            int rows = 2;
            int columns = 0;

            Assert.That(() => MatrixTrace.Check.RowsAndColumns(rows, columns), Throws.ArgumentException);
        }


        [Test]
        public void MatrixInput_ArgumentIsNull_ThrowArgumentException()
        {
            Assert.That(() => MatrixTrace.Check.MatrixInput(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ArrayInput_ArgumentIsNull_ThrowArgumentException()
        {
            Assert.That(() => MatrixTrace.Check.ArrayInput(null), Throws.ArgumentNullException);
        }
    }
}
