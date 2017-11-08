using System.ComponentModel.DataAnnotations; // This is for validations

namespace theWall.Models
{
    public abstract class BaseEntity {}
    public class User: BaseEntity
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Only letters for name")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Only letters for name")]
        public string LastName {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password's do not match")]
        public string ConfirmPassword {get; set;}

        [Required]
        [EmailAddress]
        public string Email {get; set;}

    }
}