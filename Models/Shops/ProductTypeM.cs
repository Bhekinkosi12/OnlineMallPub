using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMall.Models.Shops
{
    public class ProductTypeM
    {
        public int ShopId { get; set; }
        public string ProductType { get; set; }
        public string? ProductTypeLink { get; set; }
        public List<ProductM> Products { get; set; }
    }
}
