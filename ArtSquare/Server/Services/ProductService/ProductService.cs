using ArtSquare.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArtSquare.Server.Data;

namespace ArtSquare.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ArtSquareServerContext _context;
        public ProductService(ArtSquareServerContext context)
        {
            _context = context;
        }
        //public List<Product> Products { get; set; } = new List<Product>();
        

        public async Task<List<Product>> SetUp()
        {
            //loadTxt();
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            //loadTxt();

            return await _context.Products.ToListAsync();

        }


        public async Task<Product> GetProduct(int id)
        {
            //loadTxt();
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProduct(Product p)
        {
           
            await _context.AddAsync<Product>(p);
            _context.SaveChanges();
        }

        
    }
}
