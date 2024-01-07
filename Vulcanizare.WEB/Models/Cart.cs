﻿namespace Vulcanizare.WEB.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}