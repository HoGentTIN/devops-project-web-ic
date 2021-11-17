using ArtSquare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Client.Services.ProductService
{
    interface IProductService
    {
        List<Product> Products { get; set; }
        Task LoadProducts();
        Task<Product> GetProduct(int id);

        Task AddProduct(string name, string description, double price, int width, int height);
    }
}
