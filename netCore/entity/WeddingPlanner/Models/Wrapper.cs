using System.ComponentModel.DataAnnotations; // This is for validations
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wrapper: BaseEntity
    {
        public User users {get; set;}
        public Wedding weddings {get; set;}

    }
}