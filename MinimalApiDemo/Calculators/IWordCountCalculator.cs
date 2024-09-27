using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators
{
    public interface IWordCountCalculator
    {
        Dictionary<string, int> CalculateWordCount(WordCountRequest request);
    }
}
