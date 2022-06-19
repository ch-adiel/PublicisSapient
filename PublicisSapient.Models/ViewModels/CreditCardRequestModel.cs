using PublicisSapient.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace PublicisSapient.Models.ViewModels
{
    public class CreditCardRequestModel
    {
        [Required]
        public string CardName { get; set; }
        [Required]
        [CardNumberValidator]
        public string CardNumber { get; set; }
        [Required]
        [CardLimitValidator(0)]
        public decimal CardLimit { get; set; }
    }
}
