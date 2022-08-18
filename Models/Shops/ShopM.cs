using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OnlineMall.Models.Shops
{
    public class ShopM
    {
        public ShopM()
        {
            AvailableSale = new List<ProductM>();
            PlatformShopModel = new PlatformShopM();
            SearchGuess = new List<NameM>();
        }
        public int Id { get; set; }
        [Required]
         public string Name { get; set; }
        public bool isConfirmed { get; set; } = false;
        public string? IntroVideo { get; set; }
        public string Location { get; set; }
        [Required]
        [Url]
        public string Website { get; set; }
        [Required]
        [Phone]
        public string BusinessNumber { get; set; }
        [Required]
        public string EnterpriceNumber { get; set; }
        public string? Logo { get; set; }
        public string Image { get; set; }  
        public string Profile { get; set; }
        public string WaterMark { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Slogan { get; set; }
        public List<ProductM> AvailableSale { get; set; }
        public PlatformShopM PlatformShopModel { get; set; }
        public string? Splash { get; set; }
        public List<NameM> SearchGuess { get; set; }
        public ShopStatusM ShopStatus { get; set; } = ShopStatusM.Success;


    }

    public enum ShopStatusM
    {
        Success,
        Warning,
        Error
    }

}
