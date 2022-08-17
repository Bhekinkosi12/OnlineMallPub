using System;
using System.Collections.Generic;
using System.Text;
using OnlineMall.Models.Shops;
using System.Threading.Tasks;
using OnlineMall.Services.ShopServices;

using OnlineMall.FirebaseDB.DataBase;

namespace OnlineMall.FirebaseDB.DataBase.DatabaseMicroServices
{
    internal class ShopDatabaseExtra
    {
        private static ShopM _shop = new ShopM(); 
        public ShopDatabaseExtra()
        {

        }
        ICrudService<ShopM> _crud;
        ShopDatabaseExtra extra = new ShopDatabaseExtra();
        ShopDatabase shopDatabase = new ShopDatabase();
        public ShopDatabaseExtra(ICrudService<ShopM> crud)
        {
            _crud = crud;
        }

        public async Task<ShopM> GetShopById(int id)
        {
            var item = await shopDatabase.GetAllAsync();
           return item[id];


        }


        public async Task<ShopM> GetShopById()
        {
            
            //var item = await _crud.GetAllAsync();
            var item = await shopDatabase.GetAllAsync();
            return item[0];


        }

        public ShopM ReturnUserShop()
        {
            return _shop;
        }
        public void SetUserShop(ShopM shop)
        {
            _shop = shop;
        }

        public void SaveShopID(string id)
        {
            //Preferences.Set("ShopId",id);
        }
       

    }
}
