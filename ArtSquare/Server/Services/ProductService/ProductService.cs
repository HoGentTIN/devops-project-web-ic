using ArtSquare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; } = new List<Product>
        {
            new Product
                    {
                        Id = 1,
                        Name = "The Scream",
                        Price = 54.50,
                        ImgPath = "/Images/art2.jpg",
                        Deadline = DateTime.Now,
                        IsAuction = false,
                        Width = 600,
                        Height = 400,
                        Desciption = "This photo was taken in a small village in Istra Croatia.",

                    },

            new Product
            {
                Id = 2,
                Name = "Rainbow",
                Price = 63.90,
                ImgPath = "example.jpg",
                Deadline = DateTime.Now,
                IsAuction = false,
                Width = 200,
                Height = 200,
                Desciption = "This photo was taken in a small village in Istra Croatia.",
            }
        };

        public async Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProducts()
        {
            return Products;

        }
    }
}
