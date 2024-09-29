using MinimalApiDemo.Calculators;
using MinimalApiDemo.RequestModels;


namespace MinimalApiDemo.UnitTests.Calculators
{
    [TestClass]
    public class CharCountCalculatorTests
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

            var request = new CharCountModel
            {
                Text = inputText,
                CharsToCount = [],
            };

            // act
            var result = calculator.Calculate(request);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        [DataRow(new char[] { 'a', 'd', 'g', 'z' },
                 new int[] { 1, 2, 3, 0 })]
        public void MultipleCharsToCountTest(char[] charsToCount, int[] expectedCounts)
        {
            // arrange
            var calculator = CreateInstance();

            var request = new CharCountModel
            {
                Text = "abc def def ghi ghi ghi",
                CharsToCount = charsToCount,
            };

            // act
            var result = calculator.Calculate(request);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(charsToCount.Length, result.Count);

            for (int i = 0; i < charsToCount.Length; i++)
            {
                var charToCount = charsToCount[i];
                var expectedCharToCount = expectedCounts[i];

                Assert.IsTrue(result.ContainsKey(charToCount));
                Assert.AreEqual(expectedCharToCount, result[charToCount]);
            }
        }

        private static CharCountCalculator CreateInstance()
        {
            return new CharCountCalculator(new TextCalculator());
        }
    }
}
