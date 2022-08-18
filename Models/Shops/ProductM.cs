using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OnlineMall.Models.Shops
{
    public class ProductM
    {

        public ProductM()
        {
            ProductTheme = new ProductTheme();
            SearchGuess = new List<NameM>();
        }

        public int AutoId { get; set; }
        public string Id { get; set; } = $"{Guid.NewGuid()}asd{Guid.NewGuid()}";
        public string ShopName { get; set; }
        public string? ProductShopID { get; set;}
        public int ShopID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public DateTime LastSaleDay { get; set; }
        public bool IsSale { get; set; } = false;
        public bool IsLimited { get; set; }
        public double LimitedNumber { get; set; }
        public string SaleCaption { get; set; } = "Sale";
        [Required]
        public string Link { get; set; }
        public string Image { get; set; }
        public ProductTheme ProductTheme { get; set; }
        public List<NameM> SearchGuess { get; set; }


    }
    public class NameM
    {
        public string Name { get; set; }
    }
}
