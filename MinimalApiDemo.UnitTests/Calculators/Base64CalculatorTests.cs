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
        [DataRow("1234567890ß@|.!/&%asdf qwer")]
        public void CheckBase64StringsReturnsTrueTest(string inputString)
        {
            // arrange
            var calculator = CreateInstance();
            var bytes = Encoding.UTF8.GetBytes(inputString);
            var base64String = Convert.ToBase64String(bytes);

            Console.WriteLine(base64String);

            var model = new TextModel
            {
                Text = base64String,
            };

            // act
            var result = calculator.CalculateIsBase64String(model);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("This is a sample text.")]
        [DataRow("1234567890ß@|.!/&%asdf qwer")]
        public void CheckNonBase64StringsReturnsFalseTest(string inputString)
        {
            // arrange
            var calculator = CreateInstance();

            var model = new TextModel
            {
                Text = inputString,
            };

            // act
            var result = calculator.CalculateIsBase64String(model);

            // assert
            Assert.IsFalse(result);
        }

        private static Base64Calculator CreateInstance()
        {
            return new Base64Calculator();
        }
    }
}
