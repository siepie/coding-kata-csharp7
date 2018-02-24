using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void FizzBuzzReturnsWords()
        {
            var list = PopulateList();
            var result = FizzBuzz.FizzAndBuzz(list);
            result.Should().BeEquivalentTo(GetExpectedResult());
        }

        [Fact]
        public void FizzBuzzWithStringInput()
        {
            var input = new List<object>
            {
                1, 2, "3", "4", 5, 6, 7, 8, 9, 10, "11", "12", 13, 14, 15
            };
            var expected = new List<string>
            {
                "1",
                "2",
                "Fizz",
                "4",
                "Buzz",
                "Fizz",
                "7",
                "8",
                "Fizz",
                "Buzz",
                "11",
                "Fizz",
                "13",
                "14",
                "FizzBuzz"
            };
            var result = FizzBuzz.FizzAndBuzz(input);
            result.Should().BeEquivalentTo(expected);
        }

        private List<object> PopulateList()
        {
            var list = new List<object>();
            for (var i = 1; i <= 100; i++)
            {
                list.Add(i);
            }
            return list;
        }

        private List<string> GetExpectedResult()
        {
            var list = new List<string>
            {
                "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz",
                "16", "17", "Fizz", "19", "Buzz", "Fizz", "22", "23", "Fizz", "Buzz", "26", "Fizz", "28", "29", "FizzBuzz", "31",
                "32", "Fizz", "34", "Buzz", "Fizz", "37", "38", "Fizz", "Buzz", "41", "Fizz", "43", "44", "FizzBuzz", "46", "47", "Fizz",
                "49", "Buzz", "Fizz", "52", "53", "Fizz", "Buzz", "56", "Fizz", "58","59", "FizzBuzz", "61", "62", "Fizz", "64", "Buzz",
                "Fizz", "67", "68", "Fizz", "Buzz", "71", "Fizz", "73", "74", "FizzBuzz", "76", "77", "Fizz", "79", "Buzz", "Fizz", "82",
                "83", "Fizz", "Buzz", "86", "Fizz", "88", "89", "FizzBuzz", "91", "92", "Fizz", "94", "Buzz", "Fizz", "97", "98", "Fizz", "Buzz"
            };

            return list;
        }
    }
}
