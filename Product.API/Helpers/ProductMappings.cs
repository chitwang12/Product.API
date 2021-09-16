using AutoMapper;
using Product.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Helpers
{
    public class ProductMappings :Profile
    {
        public ProductMappings()
        {
            CreateMap<Product,ProductModel>
            
        }
    }
}
