using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public class ProductWrapper : BaseEntity
    {
        public List<Product> products { get; set; }
        public Search filter {get; set;}
        public ProductWrapper(List<Product> theproducts, Search thefilter)
        {
            products = theproducts;
            filter = thefilter;
        }
    }
}