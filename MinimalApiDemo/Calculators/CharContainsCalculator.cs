using MinimalApiDemo.Calculators.Interfaces;
using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators
{
    internal class CharContainsCalculator(ITextCalculator textCalculator) : ICharContainsCalculator
    {
        private readonly ITextCalculator textCalculator = textCalculator;

        public Dictionary<char, bool> Calculate(CharContainsModel request)
        {
            if (request.CharsToCheck.Length == 0)
            {
                return [];
            }

            var result = this.textCalculator.CheckOccurences(request.Text, request.CharsToCheck, false);

            return result.Select(entry => (entry.Key, entry.Value == 1)).ToDictionary();
        }
    }
}
