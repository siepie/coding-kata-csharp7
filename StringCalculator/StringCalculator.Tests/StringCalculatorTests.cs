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
    }
}
