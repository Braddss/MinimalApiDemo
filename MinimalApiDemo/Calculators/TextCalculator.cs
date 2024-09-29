using MinimalApiDemo.Calculators.Interfaces;

namespace MinimalApiDemo.Calculators
{
    internal class TextCalculator : ITextCalculator
    {
        public Dictionary<string, int> CheckOccurences(string inputText, string[] entriesToCheck, bool checkForMultipleOccurences)
        {
            var wordList = inputText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (entriesToCheck.Length == 0)
            {
                return new() { { string.Empty, checkForMultipleOccurences ? wordList.Length : wordList.Length == 0 ? 0 : 1 } };
            }

            Dictionary<string, int> wordCount;

            wordCount = entriesToCheck.ToDictionary(
                word => word,
                word => 
                {
                    return checkForMultipleOccurences
                    ? wordList.Count(w => w.Contains(word, StringComparison.OrdinalIgnoreCase))
                    : wordList.Any(w => w.Contains(word, StringComparison.OrdinalIgnoreCase)) ? 1 : 0;
                });


            return wordCount;
        }

        public Dictionary<char, int> CheckOccurences(string inputText, char[] entriesToCheck, bool checkForMultipleOccurences)
        {
            if (entriesToCheck.Length == 0)
            {
                return [];
            }

            Dictionary<char, int> charCount;

            if (checkForMultipleOccurences)
            {
                charCount = entriesToCheck.ToDictionary(
                    character => character,
                    character => inputText.Count(inputCharacter => char.ToUpper(inputCharacter) == char.ToUpper(character)));
            }
            else
            {
                charCount = entriesToCheck.ToDictionary(
                    character => character,
                    character => inputText.Any(inputCharacter => char.ToUpper(inputCharacter) == char.ToUpper(character)) ? 1 : 0);
            }


            return charCount;
        }
    }
}
