namespace PublicisSapient.Models.Exceptions
{
    public class CreditCardLimitException : AppException
    {
        public CreditCardLimitException() { }

        public CreditCardLimitException(double minLimit, double enteredLimit) 
            : base(string.Format("Entered Credit card limit {0} is less than minimum limit {1}", enteredLimit, minLimit))
        {
        }
    }
}
