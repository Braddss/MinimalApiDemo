using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.Calculators.Interfaces
{
    internal interface IBase64Calculator
    {
        bool CalculateIsBase64String(BaseModel model);
    }
}
