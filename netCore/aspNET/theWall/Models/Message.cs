using System.ComponentModel.DataAnnotations; // This is for validations

namespace theWall.Models
{
    public class Message: BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Content {get; set;}
    }
}