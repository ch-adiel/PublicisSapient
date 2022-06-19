using PublicisSapient.Models.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace PublicisSapient.Models.ValidationAttributes
{
    public class CardNumberValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string cardNumber = value as string;

            if (!string.IsNullOrEmpty(cardNumber))
            {
                var isValid = Luhn10.ValidateCardNumber(cardNumber);

                if (!isValid)
                    throw new CreditCardNumberException(cardNumber);

                return isValid;
            }

            return false;
        }
    }
}
