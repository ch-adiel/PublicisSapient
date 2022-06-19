namespace PublicisSapient.Models.Exceptions
{
    public class CreditCardNumberException : AppException
    {
        public CreditCardNumberException() { }

        public CreditCardNumberException(string cardNumber) 
            : base(string.Format("Entered Credit card number {0} is invalid", cardNumber))
        {
        }
    }
}
