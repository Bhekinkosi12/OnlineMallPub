using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using OnlineMall.Services.ShopServices;
using OnlineMall.Models.Filters;
using System.Threading.Tasks;

namespace OnlineMall.FirebaseDB.DataBase
{
    internal class TabFilterDB : BaseDB, ICrudService<TabsFilterM>
    {

        FirebaseClient _client;
        private static bool isChanged = true;
        private static List<TabsFilterM> _items = new List<TabsFilterM>();
        public TabFilterDB()
        {
            FirebaseOptions firebaseOptions = new FirebaseOptions()
            {
                AsAccessToken = true,

            };

            _client = new FirebaseClient(FirebaseDatabaseID);
        }

        void Init()
        {
            List<TabsFilterM> tabs = new List<TabsFilterM>()
            {
                 new TabsFilterM
                 {
                      ClosestSuggests = new List<SugestionM>()
                      {
                          new SugestionM
                          {
                               Name = "Food"
                                
                          },
                           new SugestionM
                          {
                               Name = "Foodies"

                          }, new SugestionM
                          {
                               Name = "Ukudla"

                          },

                      },
                       Name = "Food"
                 },new TabsFilterM
                 {
                      ClosestSuggests = new List<SugestionM>()
                      {
                          new SugestionM
                          {
                               Name = "toilet"

                          },
                           new SugestionM
                          {
                               Name = "bathrom"

                          }, new SugestionM
                          {
                               Name = "geza"

                          },

                      },
                       Name = "Toileties"
                 }
            };


            _items = tabs;
        }

        public async Task<bool> CreateAsync(TabsFilterM obj)
        {
            isChanged = true;
            try
            {
               await _client.Child("TabsFilter").PostAsync(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(TabsFilterM obj)
        {
            isChanged = true;
            try
            {
               var item = (await _client.Child("TabsFilter").OnceAsync<TabsFilterM>()).ToList().FirstOrDefault(x => x.Object.Name == obj.Name);
               await _client.Child("TabsFilter").Child(item.Key).DeleteAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<TabsFilterM>> GetAllAsync()
        {
            List<TabsFilterM> tabs = new List<TabsFilterM>();

            Init();

            tabs = _items;
            /*
            if (isChanged)
            {
               var items =  (await _client.Child("TabsFilter").OnceAsync<TabsFilterM>()).ToList();

                foreach(var i in items)
                {
                    tabs.Add(i.Object);
                }

                _items = tabs;
            }
            else
            {
                tabs = _items;
            }
            */

            return await Task.FromResult(tabs);
        }

        public async Task<bool> UpdateAsync(TabsFilterM obj)
        {
            isChanged = true;
            try
            {
                var item = (await _client.Child("TabsFilter").OnceAsync<TabsFilterM>()).ToList().FirstOrDefault(x => x.Object.Name == obj.Name);
                await _client.Child("TabsFilter").Child(item.Key).PutAsync(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
