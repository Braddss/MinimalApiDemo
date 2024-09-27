using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalApiDemo.Calculators;
using MinimalApiDemo.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiDemo.UnitTests.Calculators
{
    [TestClass]
    public class WordContainsCalculatorTests
    {
        [TestMethod]
        public void EmptyArgumentsReturnsZeroWordsTest()
        {
            // arrange
            var calculator = CreateInstance();

            var request = new WordContainsModel
            {
                Text = string.Empty,
                WordsToCheck = [],
            };

            // act
            var result = calculator.Calculate(request);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        [DataRow("This is a sample text with ten words in it.")]
        [DataRow("Two words")]
        [DataRow("abc def ghi")]
        [DataRow("abc, def, ghi.")]
        public void EmptyWordsToCheckReturnsWordCountTest(string textInput)
        {
            // arrange
            var calculator = CreateInstance();

            var request = new WordContainsModel
            {
                Text = textInput,
                WordsToCheck = [],
            };

            // act
            var result = calculator.Calculate(request);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        [DataRow(new string[] { "", "this", "text", "appear", "appears", "magic" },
                 new bool[] { false, true, true, true, true, false })]
        public void MultipleWordsToCheckTest(string[] wordsToCheck, bool[] expectedContains)
        {
            // arrange
            var calculator = CreateInstance();

            var request = new WordContainsModel
            {
                Text = "This is a sample text. Some words in this text appear multiple times. Text appears three times.",
                WordsToCheck = wordsToCheck,
            };

            // act
            var result = calculator.Calculate(request);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(wordsToCheck.Length, result.Count);

            for (int i = 0; i < wordsToCheck.Length; i++)
            {
                var wordToCheck = wordsToCheck[i];
                var expectedContain = expectedContains[i];

                Assert.IsTrue(result.ContainsKey(wordToCheck));
                Assert.AreEqual(expectedContain, result[wordToCheck]);
            }
        }

        private static WordContainsCalculator CreateInstance()
        {
            return new WordContainsCalculator(new WordCountCalculator());
        }
    }
}
