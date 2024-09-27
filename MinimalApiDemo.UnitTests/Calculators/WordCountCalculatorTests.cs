using MinimalApiDemo.Calculators;
using MinimalApiDemo.RequestModels;


namespace MinimalApiDemo.UnitTests.Calculators
{
    [TestClass]
    public class WordCountCalculatorTests
    {
        [TestMethod]
        public void EmptyArgumentsReturnsZeroWordsTest()
        {
            // arrange
            var calculator = CreateInstance();

            var request = new WordCountModel
            {
                Text = string.Empty,
                WordsToCount = [],
            };

            // act
            var result = calculator.Calculate(request);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.ContainsKey(string.Empty));
            Assert.AreEqual(0, result[""]);
        }

        [TestMethod]
        [DataRow("This is a sample text with ten words in it.", 10)]
        [DataRow("Two words", 2)]
        [DataRow("abc def ghi", 3)]
        [DataRow("abc, def, ghi.", 3)]
        public void EmptyWordsToCountReturnsWordCountTest(string textInput, int expectedWordCount)
        {
            // arrange
            var calculator = CreateInstance();

            var request = new WordCountModel
            {
                Text = textInput,
                WordsToCount = [],
            };

            // act
            var result = calculator.Calculate(request);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.ContainsKey(string.Empty));
            Assert.AreEqual(expectedWordCount, result[string.Empty]);
        }

        [TestMethod]
        [DataRow(new string[] { "", "this", "text", "appear", "appears", "magic" },
                 new int[] { 17, 2, 3, 2, 1, 0 })]
        public void MultipleWordsToCountTest(string[] wordsToCount, int[] expectedCounts)
        {
            // arrange
            var calculator = CreateInstance();

            var request = new WordCountModel
            {
                Text = "This is a sample text. Some words in this text appear multiple times. Text appears three times.",
                WordsToCount = wordsToCount,
            };

            // act
            var result = calculator.Calculate(request);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(wordsToCount.Length, result.Count);

            for (int i = 0; i < wordsToCount.Length; i++)
            {
                var wordToCount = wordsToCount[i];
                var expectedWordCount = expectedCounts[i];

                Assert.IsTrue(result.ContainsKey(wordToCount));
                Assert.AreEqual(expectedWordCount, result[wordToCount]);
            }
        }

        private static WordCountCalculator CreateInstance()
        {
            return new WordCountCalculator();
        }
    }
}
