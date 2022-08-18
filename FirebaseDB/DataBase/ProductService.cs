using OnlineMall.Services.ShopServices;
using OnlineMall.Models.Shops;
using Firebase.Database;
using Firebase.Database.Query;

namespace OnlineMall.FirebaseDB.DataBase 
{
    public class ProductService : IProductService
    {
        FirebaseClient _client;

        public ProductService()
        {
            _client = new FirebaseClient("https://mzansigomall-default-rtdb.firebaseio.com");
        }

        public async Task<bool> CreateProductAsync(ProductM product)
        {
            try
            {
                var allproduct = await _client.Child("products").OnceAsync<ProductM>();
                if(allproduct != null)
                {
                    var newProduct = product;
                    newProduct.AutoId = allproduct.Count;
                    
                     var response = await _client.Child("products").PostAsync(product);
                    if(response != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

               
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<ProductM>> GetAllProduct()
        {
            List<ProductM> allproducts = new List<ProductM>();

            try
            {
                var all = await _client.Child("products").OnceAsync<ProductM>();

                if(all != null)
                {
                    foreach(var i in all)
                    {
                        allproducts.Add(i.Object);
                    }
                }

            }
            catch
            {

            }


            return await Task.FromResult(allproducts);
        }

        public async Task<ProductM?> GetProductById(string id)
        {
            try
            {
                
                var allproduct = await _client.Child("products").OnceAsync<ProductM>();

                if(allproduct != null)
                {
                    var item = allproduct.FirstOrDefault(x => x.Object.Id == id);
                    if(item != null)
                    {
                        return item.Object;
                    }
                    else
                    {
                        // search from shop list

                        ShopDatabase shopDB = new ShopDatabase();

                       var shops = await shopDB.GetAllPublicAsync();

                        if(shops.Count != 0)
                        {
                            ProductM productS = new ProductM();
                            foreach(var up in shops)
                            {
                                
                                foreach(var down in up.PlatformShopModel.productTypes)
                                {
                                    var selected = down.Products.FirstOrDefault(x => x.Id == id);
                                    if(selected != null)
                                    {
                                        productS = selected;
                                    }
                                }

                            }



                            if(string.IsNullOrEmpty(productS.Name))
                            {
                                return productS;
                            }
                            else
                            {
                                return null;
                            }



                        }
                        else
                        {
                            return null;
                        }









                    }
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

        public async Task<bool> UpdateProductAsync(ProductM product)
        {
            try
            {

                var allproduct = await _client.Child("products").OnceAsync<ProductM>();
                if(allproduct != null)
                {
                    var selected = allproduct.FirstOrDefault(x => x.Object.Id == product.Id);
                    if(selected != null)
                    {
                       await _client.Child("products").Child(selected.Key).PostAsync(product);
                    }
                    else
                    {
                       var respo = await CreateProductAsync(product);
                        if (respo)
                        {

                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
