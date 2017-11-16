using System.ComponentModel.DataAnnotations; // This is for validations
using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public class Order: BaseEntity
    {
        public int orderid {get; set;}
        public int quantity {get; set;}
        public DateTime createdat {get; set;}
        public Product product {get; set;}
        public Customer customer {get; set;}

    }
}