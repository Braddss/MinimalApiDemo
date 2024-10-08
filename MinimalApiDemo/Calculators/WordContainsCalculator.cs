﻿using MinimalApiDemo.Calculators.Interfaces;
using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators
{
    internal class WordContainsCalculator(ITextCalculator textCalculator) : IWordContainsCalculator
    {
        private readonly ITextCalculator textCalculator = textCalculator;

        public Dictionary<string, bool> Calculate(WordContainsModel request)
        {
            if (request.WordsToCheck.Length == 0)
            {
                return [];
            }

            var result = this.textCalculator.CheckOccurences(request.Text, request.WordsToCheck, false);

            return result.Select(entry => (entry.Key, entry.Value == 1)).ToDictionary();
        }
    }
}
