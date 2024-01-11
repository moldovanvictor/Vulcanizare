using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Vulcanizare.MAUI.Models
{
    public class Tire
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string TireType { get; set; }
        public string Season { get; set; }
        public int Width { get; set; }
        public int Diameter { get; set; }
        public int Profile { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}