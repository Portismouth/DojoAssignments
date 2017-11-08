using System.ComponentModel.DataAnnotations; // This is for validations

namespace theWall.Models
{
    public class Login: BaseEntity
    {

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string LoginPassword {get; set;}

        [Required]
        [EmailAddress]
        public string LoginEmail {get; set;}

    }
}