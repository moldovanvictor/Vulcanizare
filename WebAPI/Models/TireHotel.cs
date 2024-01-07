namespace WebAPI.Models
{
    public class TireHotel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TireStatus { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
