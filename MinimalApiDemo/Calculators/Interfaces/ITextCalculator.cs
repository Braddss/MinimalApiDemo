namespace MinimalApiDemo.Calculators.Interfaces
{
    internal interface ITextCalculator
    {
        public Dictionary<string, int> CheckOccurences(string inputText, string[] entriesToCheck, bool checkForMultipleOccurences);

        public Dictionary<char, int> CheckOccurences(string inputText, char[] entriesToCheck, bool checkForMultipleOccurences);
    }
}
