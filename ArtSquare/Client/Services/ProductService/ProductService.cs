using ArtSquare.Shared.Models;
using ArtSquare.Shared.Response;
using Microsoft.AspNetCore.Components.Forms;
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
        public const long maxFileSize = 1024 * 1024 * 10; // 10MB



        public List<Product> Products { get; set; } = new List<Product>();
        public List<Product> ShopProducts { get; set; } = new List<Product>();

        public int PId { get; set; } = -1;

        public Uri Uri { get; set; }


        public ProductService(HttpClient http)
        {
            _http = http;
            _publicHttp = new PublicClient(http);
        }

        public async Task UploadImageAsync(Uri sas, IBrowserFile file)
        {
            var content = new StreamContent(file.OpenReadStream(maxFileSize));
            content.Headers.Add("x-ms-blob-type", "BlockBlob");
            var response = await _http.PutAsync(sas, content);
            response.EnsureSuccessStatusCode();
        }


        public async Task GetProducts()
        {
            Products = await _http.GetFromJsonAsync<List<Product>>("api/Product");
        }
        public async Task DelShop(Product p)
        {
            await _http.PostAsJsonAsync("api/Product/DelShop", p);
        }
        public async Task DelProduct(Product p)
        {
            await _http.PostAsJsonAsync("api/Product/DelProduct", p);
        }

        public async Task GetShopItems(string id)
        {
            ShopProducts = await _http.GetFromJsonAsync<List<Product>>($"api/Product/ShopItems/{id}");
            Console.WriteLine("A");
        }



        public async Task<ProductResponse.Create> AddProduct(string name, string description, double price, int width, int height, bool isAuction, Artist artist, List<Tags> tags)
        {
            var postBody = new Product
            {
                Name = name,
                Price = price,
                ImgPath = "/Images/art2.jpg",
                IsAuction = isAuction,
                Width = width,
                Height = height,
                ArtistId = artist.Id,
                Desciption = description,
                UploadDate = DateTime.Now,
                IsAvailable = true,
                Tags = tags,
            };
            var response = await _http.PostAsJsonAsync("api/Product", postBody);
            return await response.Content.ReadFromJsonAsync<ProductResponse.Create>();
        }

        public async Task BuyItem(Product p)
        {
            await _http.PutAsJsonAsync<Product>("api/Product/BuyItem", p);
        }

        public async Task AddShop(ShoppingCart sc)
        {
            
            await _http.PostAsJsonAsync("api/Product/AddShop", sc);
        }

        public Task LoadProducts()
        {
            throw new NotImplementedException();
        }

        public async Task AddAuction(DateTime deadline, double minPrice, double maxPrice, int p)
        {
            var postBody = new Auction
            {
                Deadline = deadline,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                
                ProductId = p,
            };
            await _http.PostAsJsonAsync("api/Product/Auction", postBody);
        }

        public Task AddTags(int id, Tags tag)
        {
            throw new NotImplementedException();
        }
    }
}
