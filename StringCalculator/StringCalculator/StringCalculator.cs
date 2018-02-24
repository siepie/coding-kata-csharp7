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
                string[] delimiters = GetDelimeters();
                if (numbers.StartsWith("//"))
                {
                    numbers = numbers.AfterFirst("\n");
                }

                var input = numbers.Split(delimiters, StringSplitOptions.None);
                return input.Select(number => int.TryParse(number, out var parsedNumber) ? parsedNumber : 0).ToList();

                string[] GetDelimeters()
                {
                    var delimitersList = new List<string>();
                    if (numbers.StartsWith("//"))
                    {
                        var customDelimiters = numbers.Between("//", "\n");
                        if (customDelimiters.Count(c => c == '[') > 0)
                        {
                            delimitersList = customDelimiters.Split('[', ']').Where((item, index) => index % 2 != 0)
                                .ToList();
                        }
                        else
                        {
                            delimitersList.Add(customDelimiters);
                        }
                    }
                    delimitersList.Add(",");
                    delimitersList.Add("\n");
                    return delimitersList.ToArray();
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
