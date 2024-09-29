using System.Text;
using MinimalApiDemo.Calculators;
using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.UnitTests.Calculators
{
    [TestClass]
    public class Base64CalculatorTests
    {
        [TestMethod]
        [DataRow("")]
        [DataRow("This is a sample text.")]
        public void MyTestMethod(string inputString)
        {
            // arrange
            var calculator = CreateInstance();
            var bytes = Encoding.UTF8.GetBytes(inputString);
            var base64String = Convert.ToBase64String(bytes);

            var model = new BaseModel
            {
                Text = base64String,
            };

            // act
            var result = calculator.CalculateIsBase64String();

            // assert

        }

        private static Base64Calculator CreateInstance()
        {
            return new Base64Calculator();
        }
    }
}
