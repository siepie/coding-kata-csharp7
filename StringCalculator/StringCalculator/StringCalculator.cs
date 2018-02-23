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

            var numbersToCalc = GetNumbersFromString();

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

                var input = numbers.Split(new string[] { ",", "\n", customDelimeter }, StringSplitOptions.None);
                return input.Select(number => int.TryParse(number, out var parsedNumber) ? parsedNumber : 0).ToList();

                string GetCustomDelimeter()
                {
                    if (numbers.StartsWith("//"))
                    {
                        return numbers.Between("//", "\n");
                    }
                    return "";
                }
            }


        }
    }

}
