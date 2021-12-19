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
        private readonly PublicClient _publicHttp;


        public List<Product> Products { get; set; } = new List<Product>();

        public ProductService(HttpClient http)
        {
            _http = http;
            _publicHttp = new PublicClient(http);
        }


        

        public async Task GetProducts()
        {
            Products = await _http.GetFromJsonAsync<List<Product>>("api/Product");
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _http.GetFromJsonAsync<Product>($"api/Product/{id}");
        }

        public async Task AddProduct(string name, string description, double price, int width, int height, bool isAuction, Artist artist)
        {
            var postBody = new Product
            {
                Name = name,
                Price = price,
                ImgPath = "/Images/art2.jpg",
                IsAuction = isAuction,
                Width = width,
                Height = height,
                ArtistId=artist.Id,
                Artist = artist,
                Desciption = description,
                UploadDate = DateTime.Now
            };
            await _http.PostAsJsonAsync<Product>("api/Product", postBody);
        }

        public Task LoadProducts()
        {
            throw new NotImplementedException();
        }
    }
}
