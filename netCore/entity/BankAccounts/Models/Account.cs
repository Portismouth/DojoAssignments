using System.ComponentModel.DataAnnotations; // This is for validations
using System;
using System.Globalization;

namespace BankAccounts.Models
{
    public class Account: BaseEntity
    {
        public int id {get; set;}
        public int change {get; set;}
        public int Users_id {get; set;}
        public DateTime date {get; set;}
    }
}