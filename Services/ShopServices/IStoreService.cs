using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMall.Services.ShopServices
{
    internal interface IStoreService<T>
    {
        Task<bool> CreateStore(T obj);
        Task<bool> DeleteStore(T obj);
        Task<bool> UpdateStore(T obj);
        Task<List<T>> GetAllStores();

    }
}
