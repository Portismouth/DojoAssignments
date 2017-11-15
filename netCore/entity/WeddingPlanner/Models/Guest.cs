namespace WeddingPlanner.Models
{
    public class Guest : BaseEntity
    {
        public int guestid { get; set; }
 
        public int userid { get; set; }
        public User user { get; set; }
 
        public int weddingid { get; set; }
        public Wedding wedding { get; set; }
    }
}