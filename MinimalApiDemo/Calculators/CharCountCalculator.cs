using MinimalApiDemo.Calculators.Interfaces;
using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators
{
    internal class CharCountCalculator(ITextCalculator textCalculator) : ICharCountCalculator
    {
        private readonly ITextCalculator textCalculator = textCalculator;

        public Dictionary<char, int> Calculate(CharCountModel request)
        {
            return this.textCalculator.CheckOccurences(request.Text, request.CharsToCount, true);
        }
    }
}
