using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators.Interfaces
{
    internal interface IDecimalConversionCalculator
    {
        string CalculateConversion(TextModel request);
    }
}
