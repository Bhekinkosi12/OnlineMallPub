using System;
using System.Collections.Generic;
using System.Text;
using OnlineMall.Models.Shops;
using OnlineMall.Models.Users.Credits;
using System.ComponentModel.DataAnnotations;

namespace OnlineMall.Models.Users
{
    public class UserM
    {
        public UserM()
        {
            Carts = new List<CartM>();
            Credit = new CreditM();
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
        public string Role { get; set; } = "User";
        public double MGMBucks { get; set; }
        public CreditM Credit { get; set; }
        public List<CartM> Carts { get; set; }

        public List<CartM> BudgetCart { get; set; }

        public bool IsDarkMode { get; set; } = false;

    }
}
