using Xunit;

namespace CalculationEngine.Core.Tests
{
    public class CalculationTests
    {
        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(100,50,150)]
        public void AdditionTests(int a, int b, int expected)
        {
            var actual = Calculation.Addition(a, b);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-10,20, -30)]
        [InlineData(-10, -20, 10)]
        public void SubtractionTests(int a, int b, int expected)
        {
            var actual = Calculation.Subtraction(a, b);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 10, 100)]
        [InlineData(10, -10, -100)]
        public void MultiplicationTests(int a, int b, int expected)
        {
            var actual = Calculation.Multiplication(a, b);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(100, 10, 10)]
        [InlineData(50, 2, 25)]
        public void DivisionTests(int a, int b, int expected)
        {
            var actual = Calculation.Division(a, b);
            Assert.Equal(expected, actual);
        }
    }
}
