using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using OnlineMall.Services.ShopServices;
using OnlineMall.Models.Shops;
using System.Threading.Tasks;
using OnlineMall.LocalDB.FireBaseTester;


namespace OnlineMall.FirebaseDB.DataBase
{
    internal class ShopDatabase : BaseDB , ICrudService<ShopM>
    {
        
        FirebaseClient _client;
        private static bool isChanged = true;
        private static List<ShopM> _items = new List<ShopM>();
        public ShopDatabase()
        {
            FirebaseOptions firebaseOptions = new FirebaseOptions()
            {
                AsAccessToken = true,
                 
                  
            };
          
            _client = new FirebaseClient("https://mzansigomall-default-rtdb.firebaseio.com");
        }


        public async Task<bool> CreateAsync(ShopM obj)
        {
            isChanged = true;
            try
            {
                var respondAll = await _client.Child("Shops").OnceAsync<ShopM>();

                if(respondAll != null)
                {
                   var countItems = respondAll.Count;

                    var objectCh = obj;

                    objectCh.Id = countItems;
                    var respond = await _client.Child("Shops").PostAsync(obj);


                    if (respond == null)
                        return false;

                }
                else
                {
                    return false;
                }


              


                return true;
            }
            catch (Exception ex)
            {
              //  await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(ShopM obj)
        {
            isChanged = true;
            try
            {
               
               
               var item = (await _client.Child("Shops").OnceAsync<ShopM>()).ToList().FirstOrDefault(x => x.Object.Id == obj.Id);

               await _client.Child("Shops").Child(item.Key).DeleteAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<ShopM>> GetAllAsync()
        {
            List<ShopM> shopMs = new List<ShopM>();
            StoreTest testDB = new StoreTest();
            if (isChanged)
            {
                var items = (await _client.Child("Shops").OnceAsync<ShopM>()).ToList();
                //var items = await testDB.GetAllStores();

                foreach(var i in items)
                {
                    shopMs.Add(i.Object);

                }
                _items = shopMs;
            }
            else
            {
                shopMs = _items;
            }

            return await Task.FromResult(shopMs);
        }

        public async Task<List<ShopM>> GetAllPublicAsync()
        {
            List<ShopM> shopMs = new List<ShopM>();
            StoreTest testDB = new StoreTest();
            if (isChanged)
            {
                var items = (await _client.Child("Shops").OnceAsync<ShopM>()).ToList();
                //var items = await testDB.GetAllStores();

                foreach (var i in items)
                {
                    if (i.Object.isConfirmed)
                    {

                    shopMs.Add(i.Object);
                    }

                }
                _items = shopMs;
            }
            else
            {
                shopMs = _items;
            }

            return await Task.FromResult(shopMs);
        }

        public async Task<bool> UpdateAsync(ShopM obj)
        {
            isChanged = true;
            try
            {
                var item = (await _client.Child("Shops").OnceAsync<ShopM>()).ToList().FirstOrDefault(x => x.Object.Id == obj.Id);

                await _client.Child("Shops").Child(item.Key).PutAsync(obj);



                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ShopM?>? GetStoreByEmail(string email)
        {
            try
            {
                var item = (await _client.Child("Shops").OnceAsync<ShopM>()).ToList().FirstOrDefault(x => x.Object.Email == email);


                if(item != null)
                {
                    return item.Object;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }


        public async Task<ShopM?>? GetLocalStore()
        {
            try
            {
                return null;

            }
            catch
            {
                return null;
            }
        }



    }
}
