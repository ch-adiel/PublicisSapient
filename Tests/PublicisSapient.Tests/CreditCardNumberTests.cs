using NUnit.Framework;
using PublicisSapient.Models.ValidationAttributes;

namespace PublicisSapient.Tests
{
    [TestFixture]
    public class CreditCardNumberTests
    {
        [Test]
        public void WhenCardNumberInvalid_ThenInvalidCardNumberError()
        {
            Assert.IsFalse(Luhn10.ValidateCardNumber("1234567890123456"));
        }

        [Test]
        public void WhenCardNumberValid_ThenNoError()
        {
            Assert.IsTrue(Luhn10.ValidateCardNumber("5105105105105100"));
        }
    }
}
