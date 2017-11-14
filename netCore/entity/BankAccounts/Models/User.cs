using System.ComponentModel.DataAnnotations; // This is for validations

namespace BankAccounts.Models
{
    public abstract class BaseEntity {}
    public class User: BaseEntity
    {
        public int id {get; set;}
        public string firstname {get; set;}
        public string lastname {get; set;}
        public string password {get; set;}
        public string email {get; set;}
        public double balance {get; set;}

        public void bal()
        {
            this.balance = 0.00;
        }

    }
}