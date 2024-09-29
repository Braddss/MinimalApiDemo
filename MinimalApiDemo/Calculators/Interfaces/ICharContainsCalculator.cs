using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators.Interfaces
{
    internal interface ICharContainsCalculator
    {
        Dictionary<char, bool> Calculate(CharContainsModel request);
    }
}
