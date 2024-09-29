namespace MinimalApiDemo.UnitTests.Calculators
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MinimalApiDemo.Calculators;
    using MinimalApiDemo.RequestModels;

    [TestClass]
    public class DecimalConversionCalculatorTests
    {
        [TestMethod]
        // from pdf
        [DataRow("1500,3025", "1500,3025")]
        [DataRow("1500.3025", "1500,3025")]
        [DataRow("1500, 3025", "1500,3025")]
        [DataRow("1500. 3025", "1500,3025")]
        [DataRow("1500,00302500", "1500,00302500")]
        [DataRow("1500.00302500", "1500,00302500")]
        [DataRow("1,500.3025", "1500,3025")]
        [DataRow("1.500.3025", "1500,3025")]
        [DataRow("1,600,500.3025", "1600500,3025")]
        [DataRow("1.600,500.3025", "1600500,3025")]
        [DataRow("1,6.00,500.3025", "1600500,3025")]
        [DataRow("1,6.00.500.3025", "1600500,3025")]
        [DataRow("1_6_00_500_3025", "16005003025")]
        [DataRow("1_6_00_500.3025", "1600500,3025")]
        [DataRow("1_6_00_500_3025.01", "16005003025,01")]
        [DataRow("1_6_00_500.3025.01", "16005003025,01")]
        [DataRow("1,6.00,500.3025m", "1600500,3025")]
        [DataRow("1,6.00.500.3025m", "1600500,3025")]
        [DataRow("f1,600,500.3025", "0")]
        [DataRow("f1.600,500.3025", "0")]
        // own tests
        [DataRow(".123", "0,123")]
        [DataRow("123.", "123")]
        [DataRow("", "0")]
        public void DecimalConversionReturnsExpectedTest(string input, string expectedOutput)
        {
            // arrange
            DecimalConversionCalculator calculator = CreateInstance();
            TextModel textModel = new TextModel { Text = input };

            // act
            string result = calculator.CalculateConversion(textModel);

            // assert
            Assert.AreEqual(expectedOutput, result);
        }

        private static DecimalConversionCalculator CreateInstance()
        {
            return new DecimalConversionCalculator();
        }
    }
}
