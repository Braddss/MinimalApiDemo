using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators.Interfaces
{
    internal interface IMailCalculator
    {
        bool CalculateIsValidMail(TextModel model);
    }
}
