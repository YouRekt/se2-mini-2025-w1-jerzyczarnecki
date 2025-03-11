using TDD;

namespace CalcTests
{
    [TestClass]
    public sealed class CalcTest
    {
        [TestMethod]
        public void TestStringReturnsZero()
        {
            // Given
            string a = "";
            int expectedResult = 0;

            //When
            int result = Calculator.Calc(a);

            //Then
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void TestSingleNumberReturnsValue()
        {
            //Given
            string a = "420";
            int expectedResult = 420;

            //When
            int result = Calculator.Calc(a);

            //Then
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void TwoNumbersCommaDelimitedReturnSum()
        {
            //Given
            string a = "21,37";
            int expectedResult = 58;

            //When
            int result = Calculator.Calc(a);

            //Then
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void TwoNumbersNewlineDelimitedReturnSum()
        {
            //Given
            string a = "21\n37";
            int expectedResult = 58;

            //When
            int result = Calculator.Calc(a);

            //Then
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ThreeNumbersCommaDelimitedReturnSum()
        {
            //Given
            string a = "1,2,3";
            int expectedResult = 6;

            //When
            int result = Calculator.Calc(a);

            //Then
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ThreeNumbersNewlineDelimitedReturnSum()
        {
            //Given
            string a = "1\n2\n3";
            int expectedResult = 6;

            //When
            int result = Calculator.Calc(a);

            //Then
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Negative numbers not allowed.")]
        public void NegativeNumbersThrowException()
        {
            //Given
            string a = "-1";

            //When
            int result = Calculator.Calc(a);

            //Then
            Assert.Fail();
        }

        [TestMethod]
        public void NumbersGreaterThan1000AreIgnored()
        {
            //Given
            string a = "2137,1,2";
            int expectedResult = 3;

            //When
            int result = Calculator.Calc(a);

            //Then
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ASingleCharDelimiterCanBeDefinedOnTheFirstLine()
        {
            //Given
            string a = "//#1#2#3";
            int expectedResult = 6;

            //When
            int result = Calculator.Calc(a);

            //Then
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void AMultiCharDelimiterCanBeDefinedOnTheFirstLine()
        {
            //Given
            string a = "//[###]1###2###3";
            int expectedResult = 6;

            //When
            int result = Calculator.Calc(a);

            //Then
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ManySingleOrMultiCharDelimitersCanBeDefined()
        {
            //Given
            string a = "//[###][@]1###2@3";
            int expectedResult = 6;

            //When
            int result = Calculator.Calc(a);

            //Then
            Assert.AreEqual(result, expectedResult);
        }
    }
}
