
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public class StoreWrapper : BaseEntity
    {
        public List<Customer> customers { get; set; }
        public List<Order> orders { get; set; }
        public List<Product> products { get; set; }

        public StoreWrapper(List<Customer> thecustomers, List<Order> theorders, List<Product> theproducts)
        {
            customers = thecustomers;
            orders = theorders;
            products = theproducts;

        }
    }
}