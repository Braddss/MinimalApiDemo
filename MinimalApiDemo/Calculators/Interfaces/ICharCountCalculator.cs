using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators.Interfaces
{
    internal interface ICharCountCalculator
    {
        Dictionary<char, int> Calculate(CharCountModel request);
    }
}
