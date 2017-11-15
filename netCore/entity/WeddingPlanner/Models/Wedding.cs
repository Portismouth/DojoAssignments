using System.ComponentModel.DataAnnotations; // This is for validations
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding: BaseEntity
    {
        public int weddingid {get; set;}
        public string wedderone {get; set;}
        public string weddertwo {get; set;}
        public DateTime date {get; set;}
        public string address {get; set;}
        public DateTime createdat {get; set;}
        public List<Guest> guests {get; set;}
        public Wedding()
        {
            guests = new List<Guest>();
        }

    }
}