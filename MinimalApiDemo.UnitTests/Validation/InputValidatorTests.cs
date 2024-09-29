using MinimalApiDemo.Validation;

namespace MinimalApiDemo.UnitTests.Validation
{
    [TestClass]
    public class InputValidatorTests
    {
        [TestMethod]
        public void EmptyInputReturnsFalseTest()
        {
            // arrange
            var validator = CreateInstance();

            // act
            var result = validator.CheckHasDuplicates([]);

            // assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        [DataRow([""])]
        [DataRow(["hello"])]
        [DataRow(["a", "Ab", "abc", "abcd"])]
        public void InputWithoutDupesReturnsFalseTest(string[] input)
        {
            // arrange
            var validator = CreateInstance();

            // act
            var result = validator.CheckHasDuplicates(input);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow(["", ""])]
        [DataRow(["a", "A"])]
        [DataRow(["HeLlO wOrLd", "hElLo WoRlD", "test"])]
        [DataRow(["one", "two", "three", "four", "two", "five"])]
        public void InputWithDupesReturnsTrueTest(string[] input)
        {
            // arrange
            var validator = CreateInstance();

            // act
            var result = validator.CheckHasDuplicates(input);

            // assert
            Assert.IsTrue(result);
        }

        private static InputValidator CreateInstance()
        {
            return new InputValidator();
        }
    }
}
