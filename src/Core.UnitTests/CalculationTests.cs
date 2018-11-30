using System;
using FluentAssertions;
using Xunit;

namespace Core.UnitTests
{
    public class CalculationTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(10, 1, 11)]
        [InlineData(100, 1, 101)]
        public void Addition(decimal x, decimal y, decimal result)
        {
            var calculation = new Addition
            {
                X = x,
                Y = y,
            };
            calculation.Calculate().Should().Be(result);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(10, 1, 9)]
        [InlineData(100, 1, 99)]
        public void Subtraction(decimal x, decimal y, decimal result)
        {
            var calculation = new Subtraction
            {
                X = x,
                Y = y,
            };
            calculation.Calculate().Should().Be(result);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(10, 1, 10)]
        [InlineData(100, 55, 5500)]
        public void Multiplication(decimal x, decimal y, decimal result)
        {
            var calculation = new Multiplication
            {
                X = x,
                Y = y,
            };
            calculation.Calculate().Should().Be(result);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(10, 1, 10)]
        [InlineData(100, 20, 5)]
        [InlineData(100, 0, 0, false)]
        public void Division(decimal x, decimal y, decimal result, bool succeeds = true)
        {
            var calculation = new Division
            {
                X = x,
                Y = y,
            };
            if (succeeds)
                calculation.Calculate().Should().Be(result);
            else
                Assert.Throws<DivideByZeroException>(() => calculation.Calculate());
        }
    }
}