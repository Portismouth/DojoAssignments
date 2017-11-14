using System.ComponentModel.DataAnnotations; // This is for validations

namespace BankAccounts.Models
{
    public class AccountChange: BaseEntity
    {
        [Required]
        public string change {get; set;}
        [Required]
        public int amount {get; set;}
    }
}