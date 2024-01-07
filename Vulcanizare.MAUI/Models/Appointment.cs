using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulcanizare.MAUI.Models
{
    internal class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TireId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string ServiceType { get; set; }
        public int ServiceDuration { get; set; }
        public string? Status { get; set; }
        public string Comment { get; set; }
        public decimal ServicePrice { get; set; }

        // Navigation properties
        public User? User { get; set; }
        public Tire? Tire { get; set; }
    }
}
