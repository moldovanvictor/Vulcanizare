using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulcanizare.MAUI.Models
{
    internal class CartItem
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
