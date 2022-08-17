using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using OnlineMall.Services.ShopServices;
using OnlineMall.Models.Shops;
using System.Threading.Tasks;
using OnlineMall.Models.Users;

namespace OnlineMall.FirebaseDB.DataBase
{
    internal class CartDB : BaseDB, ICrudService<CartM>
    {

        FirebaseClient _client;
        private static bool isChanged = true;
        private static List<CartM> _items = new List<CartM>();
        public CartDB()
        {
            FirebaseOptions firebaseOptions = new FirebaseOptions()
            {
                AsAccessToken = true,

            };

            _client = new FirebaseClient(FirebaseDatabaseID);
        }


        public async Task<bool> CreateAsync(CartM obj)
        {
            try
            {
                await _client.Child("PublicCart").PostAsync(obj);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(CartM obj)
        {
            try
            {
                var item = (await _client.Child("PublicCart").OnceAsync<ProductM>()).ToList().FirstOrDefault(x => x.Object.Id == obj.Id);
                await _client.Child("PublicCart").Child(item.Key).DeleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<CartM>> GetAllAsync()
        {
            List<CartM> products = new List<CartM>();

            if (isChanged)
            {
                var items = (await _client.Child("PublicCart").OnceAsync<CartM>()).ToList();
                foreach (var i in items)
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

        public async Task<bool> UpdateAsync(CartM obj)
        {
            try
            {
                var item = (await _client.Child("PublicCart").OnceAsync<CartM>()).ToList().FirstOrDefault(x => x.Object.Id == obj.Id);
                await _client.Child("PublicCart").Child(item.Key).PutAsync(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
