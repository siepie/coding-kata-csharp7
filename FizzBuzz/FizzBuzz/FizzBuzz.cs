using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public static List<string> FizzAndBuzz(List<object> input)
        {
            return input.Select(GetFizzBuzzOrNumber).ToList();

            string GetFizzBuzzOrNumber(object numberForOutput)
            {
                if (numberForOutput is string s && int.TryParse(s, out var number))
                {
                    numberForOutput = number;
                }
                switch (numberForOutput)
                {
                    case int n when n % 5 == 0 && n % 3 == 0:
                        return "FizzBuzz";
                    case int n when n % 5 == 0:
                        return "Buzz";
                    case int n when n % 3 == 0:
                        return "Fizz";
                    default:
                        return numberForOutput.ToString();
                }
            }
        }
    }
}
