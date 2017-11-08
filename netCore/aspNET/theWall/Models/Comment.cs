using System.ComponentModel.DataAnnotations; // This is for validations

namespace theWall.Models
{
    public class Comment: BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string CommentContent {get; set;}
    }
}