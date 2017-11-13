using System.ComponentModel.DataAnnotations; // This is for validations


namespace restauranter.Models
{
    public class Review
    {
        public int id { get; set; }

        [Required]
        public string reviewname { get; set; }

        [Required]
        public string restaurantname { get; set; }

        [Required]
        public string review { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{MM/dd/yyy}")]
        public string date { get; set; }

        [Required]
        public int rating { get; set; }
    }
}