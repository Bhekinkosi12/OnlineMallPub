using OnlineMall.Models.Shops;

namespace OnlineMall.Services.ShopServices
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(ProductM product);
        Task<bool> UpdateProductAsync(ProductM product);
        Task<List<ProductM>> GetAllProduct();
        Task<ProductM?> GetProductById(string id);

    }
}
