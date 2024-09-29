using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators.Interfaces
{
    internal interface IWordContainsCalculator
    {
        Dictionary<string , bool> Calculate(WordContainsModel request);
    }
}
