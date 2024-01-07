using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext (DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI.Models.Tire> Tire { get; set; } = default!;

        public DbSet<WebAPI.Models.Appointment>? Appointment { get; set; }

        public DbSet<WebAPI.Models.Cart>? Cart { get; set; }

        public DbSet<WebAPI.Models.CartItem>? CartItem { get; set; }

        public DbSet<WebAPI.Models.TireHotel>? TireHotel { get; set; }

        public DbSet<WebAPI.Models.User>? User { get; set; }
    }
}
