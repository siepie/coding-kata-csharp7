using System;
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
                string customDelimeter = GetCustomDelimeter();
                if (!string.IsNullOrWhiteSpace(customDelimeter))
                {
                    numbers = numbers.After($"{customDelimeter}\n");
                }

                var input = numbers.Split(new[] { ",", "\n", customDelimeter }, StringSplitOptions.None);
                return input.Select(number => int.TryParse(number, out var parsedNumber) ? parsedNumber : 0).ToList();

                string GetCustomDelimeter()
                {
                    return numbers.StartsWith("//") ? numbers.Between("//", "\n") : "";
                }
            }

            List<int> SanitizeNumbers()
            {
                if (numbersFromInput.Any(n => n < 0))
                {
                    var message = $"Negative numbers not allowed:{string.Join(",", numbersFromInput.FindAll(n => n < 0).ToArray())}";
                    throw new NegativesNotAllowedException(message);
                }

                int[] indexes = Enumerable.Range(0, numbersFromInput.Count).Where(i => numbersFromInput[i] >= 1000).ToArray();
                Array.ForEach(indexes, i => numbersFromInput[i] = numbersFromInput[i] - 1000);

                return numbersFromInput;
            }
        }
    }

}
