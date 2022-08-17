using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using OnlineMall.Services.ShopServices;
using OnlineMall.Models.Shops;
using System.Threading.Tasks;

namespace OnlineMall.FirebaseDB.DataBase
{
    internal class SpecialDB : BaseDB, ICrudService<ProductM>
    {

        FirebaseClient _client;
        private static bool isChanged = true;
        private static List<ProductM> _items = new List<ProductM>();
        public SpecialDB()
        {
            FirebaseOptions firebaseOptions = new FirebaseOptions()
            {
                AsAccessToken = true,

            };

            _client = new FirebaseClient(FirebaseDatabaseID);
        }


        public async Task<bool> CreateAsync(ProductM obj)
        {
            try
            {
                await _client.Child("Sales").PostAsync(obj);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(ProductM obj)
        {
            try
            {
               var item = (await _client.Child("Sales").OnceAsync<ProductM>()).ToList().FirstOrDefault(x => x.Object.Id == obj.Id);
               await _client.Child("Sales").Child(item.Key).DeleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<ProductM>> GetAllAsync()
        {
            List<ProductM> products = new List<ProductM>();

            if (isChanged)
            {
                var items = (await _client.Child("Sales").OnceAsync<ProductM>()).ToList();
                foreach(var i in items)
                {
                    products.Add(i.Object);
                }

                _items = products;

            }
            else
            {
                products = _items;
            }

            return await Task.FromResult(products);
        }

        public async Task<bool> UpdateAsync(ProductM obj)
        {
            try
            {
                var item = (await _client.Child("Sales").OnceAsync<ProductM>()).ToList().FirstOrDefault(x => x.Object.Id == obj.Id);
                await _client.Child("Sales").Child(item.Key).PutAsync(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
