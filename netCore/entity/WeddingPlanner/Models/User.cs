using System.ComponentModel.DataAnnotations; // This is for validations
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public abstract class BaseEntity {}
    public class User: BaseEntity
    {
        public int userid {get; set;}
        public string firstname {get; set;}
        public string lastname {get; set;}
        public string password {get; set;}
        public string email {get; set;}
        public DateTime createdat {get; set;}
        public DateTime updatedat {get; set;}
        public List<Guest> weddings {get; set;}
        public User()
        {
            weddings = new List<Guest>();
        }

    }
}