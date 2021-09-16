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
            //bro maine code likh toh diya par yeh jo _productRepository hai yeh tere system main hogaa generated toh vahan se uthaalega yeh 
          //  subah uth kar tu ek baar yeh code apne project main daal lena chal jayega yeh 200% nahi chalega toh dekhengey phir kuch aur hisaab 
          //Baaki yeh ho gaya hai ab meri side se .
            var id = await _productRepository.AddProductAsync(productModel);
            return CreatedAtAction(nameof(searchProductById), new { id = id, controller = "Products" }, id);
        }
    }
}