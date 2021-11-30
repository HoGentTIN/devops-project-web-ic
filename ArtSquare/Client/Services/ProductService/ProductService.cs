using ArtSquare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ArtSquare.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        
        public List<Product> Products { get; set; } = new List<Product>();

        public ProductService(HttpClient http)
        {
            _http = http;
        }


        public async Task LoadProducts()
        {
            Products = await _http.GetFromJsonAsync <List<Product>> ("api/Product/SetUp");
        }

        public async Task GetProducts()
        {
            Products = await _http.GetFromJsonAsync<List<Product>>("api/Product");
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _http.GetFromJsonAsync<Product>($"api/Product/{id}");
        }

        public async Task AddProduct(string name, string description, double price, int width, int height, bool isAuction)
        {
            var postBody = new Product
            {
                Id = Products.Max(x => x.Id) + 1,
                Name = name,
                Price = price,
                ImgPath = "/Images/art2.jpg",
                IsAuction = isAuction,
                Width = width,
                Height = height,
                Desciption = description,
                UploadDate = DateTime.Now
            };
            await _http.PostAsJsonAsync<Product>("api/Product", postBody);
        }
    }
}
