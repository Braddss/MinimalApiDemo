using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators
{
    public class WordContainsCalculator(IWordCountCalculator wordCountCalculator) : IWordContainsCalculator
    {
        private readonly IWordCountCalculator wordCountCalculator = wordCountCalculator;

        public Dictionary<string, bool> Calculate(WordContainsModel request)
        {
            if (request.WordsToCheck.Length == 0)
            {
                return [];
            }

            var result = this.wordCountCalculator.Calculate(
                new WordCountModel
                {
                    Text = request.Text,
                    WordsToCount = request.WordsToCheck,
                });

            return result.Select(entry =>
            {
                if (entry.Key == string.Empty)
                {
                    return (string.Empty, false);
                }

                return (entry.Key, entry.Value != 0);
            }).ToDictionary();
        }
    }
}
