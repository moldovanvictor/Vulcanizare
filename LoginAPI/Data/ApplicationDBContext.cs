using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoginAPI.Models;

namespace LoginAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<LoginAPI.Models.UserInfo> UserInfo { get; set; } = default!;

        public DbSet<LoginAPI.Models.Tire>? Tire { get; set; }

        public DbSet<LoginAPI.Models.Appointment>? Appointment { get; set; }
    }
}
