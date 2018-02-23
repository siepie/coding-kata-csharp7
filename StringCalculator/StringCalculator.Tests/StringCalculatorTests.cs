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
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(0);
            Difference.Should().Be(0);
        }

        [Fact]
        public void CalculateWithOneNumberReturnsInputAsResultOnBoth()
        {
            string numbers = "1";
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(1);
            Difference.Should().Be(1);
        }

        [Fact]
        public void CalculateReturnsTwoPositiveNumbers()
        {
            string numbers = "9,6";
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(15);
            Difference.Should().Be(3);
        }

        [Fact]
        public void CalculateWithInputOfThreeNumbersReturnsTwoPositiveNumbers()
        {
            string numbers = "9,6,1";
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(16);
            Difference.Should().Be(2);
        }

        [Fact]
        public void CalculateWithInvalidInputUsesZeroAndReturnsPositiveNumbers()
        {
            string numbers = "9,zes,1";
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(10);
            Difference.Should().Be(8);
        }

        [Fact]
        public void CalculateWithSeveralNumbers()
        {
            string numbers = "19,4,1,2,9";
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(35);
            Difference.Should().Be(3);
        }
    }
}
