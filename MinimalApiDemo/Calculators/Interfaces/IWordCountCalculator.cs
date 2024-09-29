using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators.Interfaces
{
    internal interface IWordCountCalculator
    {
        Dictionary<string, int> Calculate(WordCountModel request);
    }
}
