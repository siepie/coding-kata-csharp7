using FluentAssertions;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void CalculateReturnsZeroAndZero()
        {
            string numbers = "";
            (int sum, int difference) expected = (0, 0);
            StringCalculator.Calculate(numbers).Should().Be(expected);
        }

        [Fact]
        public void CalculateWithOneNumberReturnsInputAsResultOnBoth()
        {
            string numbers = "1";
            (int sum, int difference) expected = (1, 1);
            StringCalculator.Calculate(numbers).Should().Be(expected);
        }

        [Fact]
        public void CalculateReturnsTwoPositiveNumbers()
        {
            string numbers = "9,6";
            (int sum, int difference) expected = (15, 3);
            StringCalculator.Calculate(numbers).Should().Be(expected);
        }

        [Fact]
        public void CalculateWithInputOfThreeNumbersReturnsTwoPositiveNumbers()
        {
            string numbers = "9,6,1";
            (int sum, int difference) expected = (16, 2);
            StringCalculator.Calculate(numbers).Should().Be(expected);
        }

        [Fact]
        public void CalculateWithInvalidInputUsesZeroAndReturnsPositiveNumbers()
        {
            string numbers = "9,zes,1";
            (int sum, int difference) expected = (10, 8);
            StringCalculator.Calculate(numbers).Should().Be(expected);
        }
    }
}
