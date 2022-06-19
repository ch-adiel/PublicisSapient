using PublicisSapient.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace PublicisSapient.Models.ViewModels
{
    public class CreditCardRequestModel
    {
        [Required]
        public string CardName { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public decimal CardLimit { get; set; }
    }
}
