namespace WebAPI.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public int? AppointmentId { get; set; }
        public int? TireId { get; set; }

        // Navigation properties
        public Cart Cart { get; set; }
        public Appointment Appointment { get; set; }
        public Tire Tire { get; set; }
    }
}
