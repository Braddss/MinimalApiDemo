using System.Globalization;
using MinimalApiDemo.Calculators.Interfaces;
using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators
{
    internal class DecimalConversionCalculator : IDecimalConversionCalculator
    {
        public string CalculateConversion(TextModel request)
        {
            string cleanedInput = request.Text.Replace(" ", string.Empty)
                                              .Replace("m", string.Empty)
                                              .Replace("_", string.Empty)
                                              .Replace("‘", string.Empty);

            cleanedInput = FixDecimalFormatting(cleanedInput);

            decimal result;

            var cultureInfo = CultureInfo.GetCultureInfo("de-de");

            try
            {
                result = decimal.Parse(cleanedInput, cultureInfo);
            }
            catch (Exception)
            {
                result = 0;
            }

            return result.ToString(cultureInfo);
        }

        private static string FixDecimalFormatting(string input)
        {
            int lastIndexOfSeparator = Math.Max(input.LastIndexOf(','), input.LastIndexOf('.'));

            if (lastIndexOfSeparator == -1)
            {
                return input;
            }

            var integerPart = input[..lastIndexOfSeparator];

            integerPart = integerPart.Replace(".", string.Empty)
                                     .Replace(",", string.Empty);

            var fractionalPart = input.AsSpan(lastIndexOfSeparator + 1);

            input = string.Concat(integerPart, ",", fractionalPart);

            return input;
        }
    }
}
