using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMall.Services.ShopServices
{
    public interface ICrudService<T> where T : class
    {
        Task<bool> CreateAsync(T obj);
        Task<bool> DeleteAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllPublicAsync()
        {
            throw new NotImplementedException();
        }
        Task<T?>? GetStoreByEmail(string email)
        {
            throw new NotImplementedException();
        }
        Task<T?>? GetLocalStore()
        {
            throw new NotImplementedException();
        }
    }
}
