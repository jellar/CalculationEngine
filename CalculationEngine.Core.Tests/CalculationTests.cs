using Xunit;

namespace CalculationEngine.Core.Tests
{
    public class CalculationTests
    {
        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(100,50,150)]
        public void AdditionTest(int a, int b, int expected)
        {
            var result = Calculation.Addition(a, b);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(-10,20, -30)]
        [InlineData(-10, -20, 10)]
        public void SubtractionTest(int a, int b, int expected)
        {
            var result = Calculation.Subtraction(a, b);
            Assert.Equal(result, expected);
        }

    }
}
