using ArtSquare.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Services.ProductService
{

    public interface IProductService
    {
        Task<List<Product>> SetUp();
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);

        Task AddProduct(Product p);


    }
}
