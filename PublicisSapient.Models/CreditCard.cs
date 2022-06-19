using PublicisSapient.Models.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace PublicisSapient.Models
{
    public class CreditCard : BaseEntity
    {
        public CreditCard()
        {
            Balance = 0;
            CreadedDate = DateTime.Now;
        }

        [Required]
        public string CardName { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public decimal CardLimit { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreadedDate { get; set; }
    }
}
