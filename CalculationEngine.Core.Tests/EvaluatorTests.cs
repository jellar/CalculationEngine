using Xunit;

namespace CalculationEngine.Core.Tests
{
    public class EvaluatorTests
    {
        [Theory]
        [InlineData("10+45-20", 35)]
        [InlineData("-10-20", -30)]
        [InlineData("10-20+30", 20)]
        [InlineData("100+200", 300)]
        [InlineData("(10-20)+30", 20)]
        [InlineData("2*3+4", 10)]
        [InlineData("(2*6)/3", 4)]
        public void AdditionSubtractionTests(string expression, int expected)
        {
            Evaluator eval = new Evaluator();
            var actual = eval.Evaluate(expression);
            Assert.Equal(expected, actual);
        }
    }
}
