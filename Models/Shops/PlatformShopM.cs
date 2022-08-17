using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMall.Models.Shops
{
    public class PlatformShopM
    {
        public PlatformShopM()
        {
            ShopTheme = new ShopTheme();
            productTypes = new List<ProductTypeM>();
        }


        public List<ProductTypeM> productTypes { get; set; }
        public ShopTheme ShopTheme { get; set; } 
    }
}
