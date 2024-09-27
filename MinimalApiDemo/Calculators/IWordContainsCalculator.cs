using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators
{
    public interface IWordContainsCalculator
    {
        Dictionary<string, bool> Calculate(WordContainsModel request);
    }
}
