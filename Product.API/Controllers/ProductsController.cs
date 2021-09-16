using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // List<ProductModel> ProductsSample = new List<ProductModel>();


        //teen method 
        /*
         * searchProductById --- GET
         * searchProductByName----GET
         * addProductRating----POST
         */
        [HttpPost]
        public async Task<IActionResult> addProductRating([FromRoute] ProductModel productModel)
        {
            var id = await _productRepository.AddProductAsync(productModel);
            return CreatedAtAction(nameof(searchProductById), new { id = id, controller = "Products" }, id);
        }
    }
}