using System.ComponentModel.DataAnnotations; // This is for validations
using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public class Product: BaseEntity
    {
        public int productid {get; set;}
        public string name {get; set;}
        public string image {get; set;}
        public string description {get; set;}
        public int quantity {get; set;}

    }
}