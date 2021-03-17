﻿using Xunit;

namespace CalculationEngine.Core.Tests
{
    public class CalculationTests
    {
        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(100,50,150)]
        public void AdditionTest(int a, int b, int expected)
        {
            var result = Calculation.Add(a, b);
            Assert.Equal(result, expected);
        }

    }
}