using Product.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repository
{
    interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIdAsync(int ProductId);
        Task<ProductModel> GetProductByNameAsync(string ProductName);

        Task<int> addProductRating(ProductModel productmodel);

    }
}
