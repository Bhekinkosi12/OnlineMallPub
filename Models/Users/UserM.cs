using System;
using System.Collections.Generic;
using System.Text;
using OnlineMall.Models.Shops;
using System.ComponentModel.DataAnnotations;

namespace OnlineMall.Models.Users
{
    public class UserM
    {
        public UserM()
        {
            Carts = new List<CartM>();
        }
        public int Id { get; set; }
        public string Image { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string? RepeatPassword { get; set; }
        public string? Token { get; set; }
        public double MGMBucks { get; set; }
        public List<CartM> Carts { get; set; }

    }
}
