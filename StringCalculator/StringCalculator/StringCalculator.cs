﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static (int Sum, int Difference) Calculate(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers)) return (0, 0);

            var numbersFromInput = GetNumbersFromString();
            var numbersToCalc = SanitizeNumbers();

            var sum = numbersToCalc.Sum();
            var difference = numbersToCalc.First();
            difference = numbersToCalc.Where((t, i) => i > 0).Aggregate(difference, (current, t) => current - t);

            return (sum, difference);

            List<int> GetNumbersFromString()
            {
                var delimiters = new List<string> { ",", "\n" };

                if (numbers.StartsWith("//"))
                {
                    GetDelimeters();
                    numbers = numbers.AfterFirst("\n");
                }

                var input = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
                return input.Select(number => int.TryParse(number, out var parsedNumber) ? parsedNumber : 0).ToList();

                void GetDelimeters()
                {
                    var customDelimiters = numbers.Between("//", "\n");
                    if (customDelimiters.Count(c => c == '[') > 0)
                    {
                        delimiters.AddRange(customDelimiters.Split('[', ']').Where((item, index) => index % 2 != 0)
                            .ToList());
                    }
                    else
                    {
                        delimiters.Add(customDelimiters);
                    }
                }
            }

            List<int> SanitizeNumbers()
            {
                if (numbersFromInput.Any(n => n < 0))
                {
                    var message = $"Negative numbers not allowed:{string.Join(",", numbersFromInput.FindAll(n => n < 0).ToArray())}";
                    throw new NegativesNotAllowedException(message);
                }

                return numbersFromInput.Select(n => n >= 1000 ? n - 1000 : n).ToList();
            }
        }
    }

}
