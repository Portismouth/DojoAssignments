using System.ComponentModel.DataAnnotations; // This is for validations
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class WeddingRegister: BaseEntity
    {
        [Required]
        public string wedderone {get; set;}
        
        [Required]
        public string weddertwo {get; set;}

        [Required]
        public DateTime date {get; set;}

        [Required]
        public string address {get; set;}

    }
}