using MinimalApiDemo.Calculators;
using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.UnitTests.Calculators
{
    [TestClass]
    public class MailCalculatorTests
    {
        [TestMethod]
        [DataRow("john.doe@example.com")]
        [DataRow("alice.smith@testmail.com")]
        [DataRow("david.williams@fakemail.org")]
        [DataRow("sarah.johnson@domain.com")]
        [DataRow("michael.brown@mycompany.com")]
        [DataRow("ab3d35.3.as.3@abc.def")]
        [DataRow("käyttäjä@esimerkki.com")]
        [DataRow("张伟@例子.公司")]
        [DataRow("étudiant@école.fr")]
        [DataRow("χρήστης@παράδειγμα.ελ")]
        [DataRow("пользователь@пример.рф")]
        public void IsValidMailReturnsTrueTest(string inputText)
        {
            // arrange
            var mailCalculator = CreateInstance();

            var textModel = new TextModel
            {
                Text = inputText,
            };

            // act
            var result = mailCalculator.CalculateIsValidMail(textModel);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("john.doe@.com")]
        [DataRow("@example.com")]
        [DataRow("alice.smith@domain")]
        [DataRow("david@domain..com")]
        [DataRow("michael@com")]
        [DataRow("user@-example.com")]
        [DataRow("john.doe@domain,com")]
        [DataRow("")]
        [DataRow("abc")]
        public void IsInvalidMailReturnsFalseTest(string inputText)
        {
            // arrange
            var mailCalculator = CreateInstance();

            var textModel = new TextModel
            {
                Text = inputText,
            };

            // act
            var result = mailCalculator.CalculateIsValidMail(textModel);

            // assert
            Assert.IsFalse(result);
        }

        private static MailCalculator CreateInstance()
        {
            return new MailCalculator();
        }
    }
}
