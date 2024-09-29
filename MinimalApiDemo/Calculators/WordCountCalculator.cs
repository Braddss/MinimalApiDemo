using MinimalApiDemo.Calculators.Interfaces;
using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators
{
    internal class WordCountCalculator(ITextCalculator textCalculator) : IWordCountCalculator
    {
        private readonly ITextCalculator textCalculator = textCalculator;

        public Dictionary<string, int> Calculate(WordCountModel request)
        {
            return this.textCalculator.CheckOccurences(request.Text, request.WordsToCount.ToArray(), true);
        }
    }
}
