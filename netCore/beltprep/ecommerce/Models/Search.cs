using System.ComponentModel.DataAnnotations; // This is for validations

namespace ecommerce.Models
{
    public class Search: BaseEntity
    {
        [Required]
        public string filter {get; set;}

    }
}