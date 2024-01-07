using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulcanizare.MAUI.Models
{
    public class Tire
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [Display(Name = "Descriere")]
        public string Description { get; set; }
        public string TireType { get; set; }
        public string Season { get; set; }
        public int Width { get; set; }
        public int Diameter { get; set; }
        public int Profile { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public string Image { get; set; }

        // Navigation properties
        //public ICollection<Appointment> Appointments { get; set; }
    }
}
