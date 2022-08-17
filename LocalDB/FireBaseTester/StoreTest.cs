using System;
using System.Collections.Generic;
using System.Text;
using OnlineMall.Services.ShopServices;
using OnlineMall.Models.Shops;
using System.Threading.Tasks;

namespace OnlineMall.LocalDB.FireBaseTester
{
    internal class StoreTest : IStoreService<ShopM>
    {

        public StoreTest()
        {
            ShopList = new List<ShopM>()
            {
                new ShopM
                {
                     Id = 1,
                      Name = "First Store",
                       Website = "www.google.com",
                        PlatformShopModel = new PlatformShopM()
                        {
                             productTypes = new List<ProductTypeM>()
                             {
                                  new ProductTypeM
                                  {
                                       ProductType = "Food",
                                        ShopId = 1,
                                         Products = new List<ProductM>()
                                         {
                                             new ProductM
                                             {
                                                   Name = "Picture Plastic chairs",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair.jpeg"
                                             },
                                               new ProductM
                                             {
                                                   Name = "Plastic ",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair2.jpeg"
                                             },
                                                 new ProductM
                                             {
                                                   Name = "Plastic chairs",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             },
                                                   new ProductM
                                             {
                                                   Name = "Plastic chairs",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             }
                                         }
                                  } ,

                                     new ProductTypeM
                                  {
                                       ProductType = "Toiletries",
                                        ShopId = 1,
                                         Products = new List<ProductM>()
                                         {
                                             new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             },
                                               new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             },
                                                 new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chairs.jpeg"
                                             },
                                                   new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chairs1.jpeg"
                                             }
                                         }
                                          
                                  } 

                             }
                        },
                          AvailableSale = new List<ProductM>()
                          {
                               new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             },
                                               new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair1.jpeg"
                                             },
                                                 new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair1.jpeg"
                                             },
                                                   new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             }
                          },
                           isConfirmed = true,
                            Location = "South africa",
                             Email = "info@google,com"
                },
                 new ShopM
                {
                     Id = 2,
                      Name = "Second Store",
                       Website = "www.google.com",
                        PlatformShopModel = new PlatformShopM()
                        {
                             productTypes = new List<ProductTypeM>()
                             {
                                  new ProductTypeM
                                  {
                                       ProductType = "Food",
                                        ShopId = 2,
                                         Products = new List<ProductM>()
                                         {
                                             new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair1.jpeg"
                                             },
                                               new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             },
                                                 new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair.jpeg"
                                             },
                                                   new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             }
                                         }
                                  } ,

                                     new ProductTypeM
                                  {
                                       ProductType = "Toiletries",
                                        ShopId = 2,
                                         Products = new List<ProductM>()
                                         {
                                             new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair.jpeg"
                                             },
                                               new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             },
                                                 new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair1.jpeg"
                                             },
                                                   new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             }
                                         }

                                  }

                             }
                        },
                          AvailableSale = new List<ProductM>()
                          {
                               new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             },
                                               new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair1.jpeg"
                                             },
                                                 new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair1.jpeg"
                                             },
                                                   new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             }
                          },
                           isConfirmed = true,
                            Location = "South africa",
                             Email = "info@google,com"
                },
                  new ShopM
                {
                     Id = 3,
                      Name = "Third Store",
                       Website = "www.google.com",
                        PlatformShopModel = new PlatformShopM()
                        {
                             productTypes = new List<ProductTypeM>()
                             {
                                  new ProductTypeM
                                  {
                                       ProductType = "Food",
                                        ShopId = 3,
                                         Products = new List<ProductM>()
                                         {
                                             new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             },
                                               new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair1.jpeg"
                                             },
                                                 new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair1.jpeg"
                                             },
                                                   new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             }
                                         }
                                  } ,

                                     new ProductTypeM
                                  {
                                       ProductType = "Toiletries",
                                        ShopId = 3,
                                         Products = new List<ProductM>()
                                         {
                                             new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             },
                                               new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair.jpeg"
                                             },
                                                 new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair1.jpeg"
                                             },
                                                   new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             }
                                         }

                                  }

                             }
                        },
                          AvailableSale = new List<ProductM>()
                          {
                               new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             },
                                               new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair1.jpeg"
                                             },
                                                 new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "chair1.jpeg"
                                             },
                                                   new ProductM
                                             {
                                                   Name = "Picture name",
                                                    Description = " aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description \n aa three to four linkes of description  ",
                                                     Id = Guid.NewGuid().ToString(),
                                                      Link = "google.com",
                                                       Price = 3200,
                                                        SalePrice = 3199.90,
                                                         Image = "plasticchair.jpeg"
                                             }
                          },
                           isConfirmed = true,
                            Location = "South africa",
                             Email = "info@google,com"
                },

            };
        }

         List<ShopM> ShopList { get; set; }

        public Task<bool> CreateStore(ShopM obj)
        {
            return Task.FromResult(true);
        }

        public Task<bool> DeleteStore(ShopM obj)
        {
            return Task.FromResult(true);
        }

        public async Task<List<ShopM>> GetAllStores()
        {
            return await Task.FromResult(ShopList);
        }

        public Task<bool> UpdateStore(ShopM obj)
        {
            return Task.FromResult(true);
        }
    }
}
