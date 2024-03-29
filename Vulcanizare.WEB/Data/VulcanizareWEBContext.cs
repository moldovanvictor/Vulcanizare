﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vulcanizare.WEB.Models;

namespace Vulcanizare.WEB.Data
{
    public class VulcanizareWEBContext : DbContext
    {
        public VulcanizareWEBContext (DbContextOptions<VulcanizareWEBContext> options)
            : base(options)
        {
        }

        public DbSet<Vulcanizare.WEB.Models.Tire> Tire { get; set; } = default!;

        public DbSet<Vulcanizare.WEB.Models.User>? User { get; set; }

        public DbSet<Vulcanizare.WEB.Models.TireHotel>? TireHotel { get; set; }

        public DbSet<Vulcanizare.WEB.Models.CartItem>? CartItem { get; set; }

        public DbSet<Vulcanizare.WEB.Models.Cart>? Cart { get; set; }

        public DbSet<Vulcanizare.WEB.Models.Appointment>? Appointment { get; set; }
    }
}
