namespace Vulcanizare.WEB.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<TireHotel> TireHotels { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }

}
