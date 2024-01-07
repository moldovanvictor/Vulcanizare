using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulcanizare.MAUI.Models
{
    internal class TireHotel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TireStatus { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
