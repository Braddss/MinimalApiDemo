using MinimalApiDemo.Calculators;
using MinimalApiDemo.RequestModels;


namespace MinimalApiDemo.UnitTests.Calculators
{
    [TestClass]
    public class CharContainsCalculatorTests
    {
        [TestMethod]
        [DataRow("")]
        [DataRow("This is a sample text with ten words in it.")]
        [DataRow("Two words")]
        [DataRow("abc def ghi")]
        [DataRow("abc, def, ghi.")]
        public void EmptyInputCharsReturnsEmptyTest(string inputText)
        {
            // arrange
            var calculator = CreateInstance();

            var request = new CharContainsModel
            {
                Text = inputText,
                CharsToCheck = [],
            };

            // act
            var result = calculator.Calculate(request);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        [DataRow(new char[] { 'a', 'd', 'g', 'z' },
                 new bool[] { true, true, true, false })]
        public void MultipleCharsToCountTest(char[] charsToCheck, bool[] expectedChars)
        {
            // arrange
            var calculator = CreateInstance();

            var request = new CharContainsModel
            {
                Text = "abc def def ghi ghi ghi",
                CharsToCheck = charsToCheck,
            };

            // act
            var result = calculator.Calculate(request);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(charsToCheck.Length, result.Count);

            for (int i = 0; i < charsToCheck.Length; i++)
            {
                var charToCount = charsToCheck[i];
                var expectedChar = expectedChars[i];

                Assert.IsTrue(result.ContainsKey(charToCount));
                Assert.AreEqual(expectedChar, result[charToCount]);
            }
        }

        private static CharContainsCalculator CreateInstance()
        {
            return new CharContainsCalculator(new TextCalculator());
        }
    }
}
