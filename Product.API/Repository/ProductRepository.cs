using AutoMapper;
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
        public ProductRepository(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductModel> searchProductById(int Id)
        {
            var records = await _context.Products.FindAsync(Id).Select(x => new ProductModel()
            {
                Id = x.Id,
            Price = x.Products.Price,
            Name = x.Name,
            Description = x.Description,
            image_name = x,image_name,
            Rating = x.Rating,
            no_of_Units = x.no_of_units;
        }).FirstOrDefaultAsync();
return records;

}
}
}/*
public async Task<BookModel> GetBookIdAsync(int bookId)
{
    //var records = await _context.Books.FindAsync(bookId).Select(x => new BookModel()
    //{
    //    Id = x.Id,
    //    Title = x.Title,
    //    Description = x.Description
    //}).FirstOrDefaultAsync();
    //return records;
    var book = await _context.Books.FindAsync(bookId);
    return _mapper.Map<BookModel>(book);