using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators
{
    internal class WordCountCalculator : IWordCountCalculator
    {
        public Dictionary<string, int> Calculate(WordCountModel request)
        {
            var wordList = request.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (request.WordsToCount.Length == 0)
            {
                return new() { { string.Empty, wordList.Length } };
            }

            var wordCount = request.WordsToCount.ToDictionary(
                    word => word,
                    word => wordList.Count(w => w.Contains(word, StringComparison.OrdinalIgnoreCase))
                );


            return wordCount;
        }
    }
}
