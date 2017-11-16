using System.ComponentModel.DataAnnotations; // This is for validations
using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public class Customer: BaseEntity
    {
        public int customerid {get; set;}
        [Required]
        public string name {get; set;}
        public List<Order> orders {get; set;}
        public DateTime createdat {get; set;}
        public Customer()
        {
            orders = new List<Order>();
        }

    }
}