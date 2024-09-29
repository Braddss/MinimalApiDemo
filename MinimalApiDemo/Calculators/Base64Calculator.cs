using MinimalApiDemo.Calculators.Interfaces;
using MinimalApiDemo.RequestModels;
using System.Buffers.Text;

namespace MinimalApiDemo.Calculators
{
    internal class Base64Calculator : IBase64Calculator
    {
        public bool CalculateIsBase64String(BaseModel model)
        {
            Span<byte> buffer = new Span<byte>(new byte[model.Text.Length]);
            return Convert.TryFromBase64String(model.Text, buffer, out int _);
        }
    }
}
