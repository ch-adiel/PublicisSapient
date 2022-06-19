using PublicisSapient.Models.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace PublicisSapient.Models.ValidationAttributes
{
    public class CardLimitValidator : RangeAttribute
    {
        public CardLimitValidator(double minimum) : base(minimum, double.MaxValue) { }

        public override bool IsValid(object value)
        {
            if (double.TryParse(value.ToString(), out double limit))
            {
                var isValid = limit > 0;

                if (!isValid)
                    throw new CreditCardLimitException((double)Minimum, limit);

                return isValid;
            }

            return false;
        }
    }
}
