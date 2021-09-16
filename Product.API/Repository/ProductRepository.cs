﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            //Convert ProductModel Data to Products(Manuualy) Best approach is to use AutoMapper
            var records = await _context.Products.Select(x => new ProductModel
            {
                Id = x.Id,
                Price = x.Price,
                Name = x.Name,
                Description = x.Description,
                Image_Name = x.Image_Name,
                Rating = x.Rating,
                No_Of_Units = x.No_Of_Units

            }).ToListAsync();
            return records;

        }
        public async Task<ProductModel> GetProductByIdAsync(int ProductId)
        {
            //Convert ProductModel Data to Products(Manuualy) Best approach is to use AutoMapper
            var records = await _context.Products.Where(x => x.Id == ProductId).Select(x => new ProductModel
            {
                Id = x.Id,
                Price = x.Price,
                Name = x.Name,
                Description = x.Description,
                Image_Name = x.Image_Name,
                Rating = x.Rating,
                No_Of_Units = x.No_Of_Units

            }).FirstOrDefaultAsync();
            return records;

        }

        public async Task<ProductModel> GetProductByNameAsync(string ProductName)
        {
            //Convert ProductModel Data to Products(Manuualy) Best approach is to use AutoMapper
            var records = await _context.Products.Where(x => x.Name == ProductName).Select(x => new ProductModel
            {
                Id = x.Id,
                Price = x.Price,
                Name = x.Name,
                Description = x.Description,
                Image_Name = x.Image_Name,
                Rating = x.Rating,
                No_Of_Units = x.No_Of_Units

            }).FirstOrDefaultAsync();
            return records;

        }
        public async Task<int> addProductRating(ProductModel productmodel)
        {
            var product = new Products()
            {
                Id = productmodel.Id,
                Rating =productmodel.Rating
            };
            _context.Products.Add(product);
           await  _context.SaveChangesAsync();
            return product.Id;
        }
    }
}