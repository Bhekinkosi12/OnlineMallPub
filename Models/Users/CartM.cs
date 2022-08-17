using System;
using System.Collections.Generic;
using System.Text;
using OnlineMall.Models.Shops;

namespace OnlineMall.Models.Users
{
    public class CartM
    {
        public CartM()
        {
            ProductList = new List<ProductM>();
        }
        public string Id { get; set; } = $"{Guid.NewGuid()}asd{Guid.NewGuid()}";
        public string? CartName { get; set; }
        public bool IsPublic { get; set; } = false;
        public List<ProductM> ProductList { get; set; }

        public DateTime DateTimeCreated { get; set; } = DateTime.Now;

    }
}
