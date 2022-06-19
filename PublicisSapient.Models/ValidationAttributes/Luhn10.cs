namespace PublicisSapient.Models.ValidationAttributes
{
    public class Luhn10
    {
        public static bool ValidateCardNumber(string cardNumber)
        {
            int nDigits = cardNumber.Length;
            int nSum = 0;
            bool isEven = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {
                int d = cardNumber[i] - '0';

                if (isEven)
                    d *= 2;

                nSum += d / 10;
                nSum += d % 10;

                isEven = !isEven;
            }
            return (nSum % 10 == 0);
        }
    }
}
