using FluentAssertions;
using System;
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

        [Fact]
        public void CalculateWithNewLineDelimiters()
        {
            string numbers = "19,4,1,2\n9";
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(35);
            Difference.Should().Be(3);
        }

        [Fact]
        public void CalculateWithOneNumberAndNewLineDelimiter()
        {
            string numbers = "19,\n";
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(19);
            Difference.Should().Be(19);
        }

        [Fact]
        public void CalculateWithCustomDelimiters()
        {
            string numbers = "//;\n19;9";
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(28);
            Difference.Should().Be(10);
        }

        [Fact]
        public void CalculateWithDefaultAndCustomDelimiters()
        {
            string numbers = "//**\n19**4,1,2\n9";
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(35);
            Difference.Should().Be(3);
        }

        [Fact]
        public void CalculateWithDefaultAndMultipleCustomDelimiters()
        {
            string numbers = "//[**][;]\n19**4,1;2\n9";
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(35);
            Difference.Should().Be(3);
        }

        [Fact]
        public void CalculateWithNegativeInputThrowsException()
        {
            string numbers = "9,-6,-1";
            Exception ex = Assert.Throws<NegativesNotAllowedException>(() => StringCalculator.Calculate(numbers));
            ex.Message.Should().Be("Negative numbers not allowed:-6,-1");
        }

        [Fact]
        public void CalculateMoreThanThousandShouldBeIgnored()
        {
            string numbers = "1009,4,1000,2";
            var (Sum, Difference) = StringCalculator.Calculate(numbers);
            Sum.Should().Be(15);
            Difference.Should().Be(3);
        }
    }
}
