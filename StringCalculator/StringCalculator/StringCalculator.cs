namespace StringCalculator
{
    public class StringCalculator
    {
        public static (int Sum, int Difference) Calculate(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return (0, 0);
            }

            var input = numbers.Split(',');
            int t = 0;
            int d = 0;
            foreach (var number in input)
            {
                t = t + GetNumberFromString(number);
                d = d - GetNumberFromString(number);
            }

            int GetNumberFromString(string number)
            {
                if (int.TryParse(number, out var parsedNumber))
                {
                    return parsedNumber;
                }
                return 0;
            }

            return (t, d);
        }
    }

}
