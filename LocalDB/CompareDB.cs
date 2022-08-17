using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using OnlineMall.Services.ShopServices;
using OnlineMall.Models.Shops;
using System.Threading.Tasks;

namespace OnlineMall.LocalDB
{
    public class CompareDB 
    {

        private static List<ProductM> CompareList { get; set; } = new List<ProductM>();


        public async Task<bool> CreateAsync(ProductM obj)
        {
            List<ProductM> list = new List<ProductM>();
            foreach(var i in CompareList)
            {
                list.Add(i);
            }
            list.Add(obj);

            CompareList = list;
            

            return true;
        }

        public async Task<bool> DeleteAsync(ProductM obj)
        {
            List<ProductM> list = new List<ProductM>();
            foreach (var i in CompareList)
            {
                if(i.Id != obj.Id)
                {

                list.Add(i);
                }
            }
            CompareList = list;
            return true;
        }

        public void Clear()
        {
            CompareList = new List<ProductM>();
        }

        public async Task<List<ProductM>> GetAllAsync()
        {
            return await Task.FromResult(CompareList);
        }

        public async Task<bool> UpdateAsync(ProductM obj)
        {
            return true;
        }
    }
}
