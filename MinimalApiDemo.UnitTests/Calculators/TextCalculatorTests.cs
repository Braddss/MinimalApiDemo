using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalApiDemo.Calculators;

namespace MinimalApiDemo.UnitTests.Calculators
{
    [TestClass]
    public class TextCalculatorTests
    {
        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void CheckOccurencesOfStringsWithEmptyArgumentsResturnsZeroWordsTest(bool checkForMultipleOccurences)
        {
            // arrange
            var textCalculator = CreateInstance();

            // act
            var result = textCalculator.CheckOccurences(string.Empty, new string[0], checkForMultipleOccurences);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(0, result[string.Empty]);
        }

        [TestMethod]
        [DataRow("This is a sample text.", 5, true)]
        [DataRow("This is a sample text.", 1, false)]
        public void CheckOccurencesOfStringsWithEmptyWordsReturnsCountTest(string inputText, int count, bool checkForMultipleOccurences)
        {
            // arrange
            var textCalculator = CreateInstance();

            // act
            var result = textCalculator.CheckOccurences(inputText, new string[0], checkForMultipleOccurences);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(count, result[string.Empty]);
        }

        [TestMethod]
        [DataRow(new string[] { "abc" }, new int[] { 1 }, true)]
        [DataRow(new string[] { "abc" }, new int[] { 1 }, false)]
        [DataRow(new string[] { "abc", "def" }, new int[] { 1, 3 }, true)]
        [DataRow(new string[] { "abc", "def" }, new int[] { 1, 1 }, false)]
        [DataRow(new string[] { "abc", "def", "xyz" }, new int[] { 1, 3, 0 }, true)]
        [DataRow(new string[] { "abc", "def", "xyz" }, new int[] { 1, 1, 0 }, false)]
        [DataRow(new string[] { "abc", "def", "" }, new int[] { 1, 3, 6 }, true)]
        [DataRow(new string[] { "abc", "def", "" }, new int[] { 1, 1, 1 }, false)]
        public void CheckOccurencesOfMultipleStringsReturnsCountTest(string[] inputStrings, int[] counts, bool checkForMultipleOccurences)
        {
            // arrange
            var textCalculator = CreateInstance();
            var inputText = "abc def def def ghi ghi";

            // act

            var result = textCalculator.CheckOccurences(inputText, inputStrings, checkForMultipleOccurences);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(inputStrings.Length, result.Count);

            for (int i = 0; i < inputStrings.Length; i++)
            {
                var inputString = inputStrings[i];
                var expectedCount = counts[i];

                Assert.AreEqual(expectedCount, result[inputString]);
            }
        }

        [TestMethod]
        [DataRow("", true)]
        [DataRow("", false)]
        [DataRow("This is a sample text.", true)]
        [DataRow("This is a sample text.", false)]
        public void CheckOccurencesWithEmptyCharsReturnsEmptyTest(string inputText, bool checkForMultipleOccurences)
        {
            // arrange
            var textCalculator = CreateInstance();

            // act
            var result = textCalculator.CheckOccurences(inputText, new char[0], checkForMultipleOccurences);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        [DataRow(new char[] { 'a' }, new int[] { 1 }, true)]
        [DataRow(new char[] { 'a' }, new int[] { 1 }, false)]
        [DataRow(new char[] { 'a', 'e' }, new int[] { 1, 3 }, true)]
        [DataRow(new char[] { 'a', 'e' }, new int[] { 1, 1 }, false)]
        [DataRow(new char[] { 'a', 'e', 'z' }, new int[] { 1, 3, 0 }, true)]
        [DataRow(new char[] { 'a', 'e', 'z' }, new int[] { 1, 1, 0 }, false)]
        public void CheckOccurencesOfMultipleStringsReturnsCountTest(char[] inputStrings, int[] counts, bool checkForMultipleOccurences)
        {
            // arrange
            var textCalculator = CreateInstance();
            var inputText = "abc def def def ghi ghi";

            // act

            var result = textCalculator.CheckOccurences(inputText, inputStrings, checkForMultipleOccurences);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(inputStrings.Length, result.Count);

            for (int i = 0; i < inputStrings.Length; i++)
            {
                var inputString = inputStrings[i];
                var expectedCount = counts[i];

                Assert.AreEqual(expectedCount, result[inputString]);
            }
        }

        private static TextCalculator CreateInstance()
        {
            return new TextCalculator();
        }
    }
}
