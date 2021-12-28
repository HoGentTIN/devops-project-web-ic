using ArtSquare.Shared.Models;
using ArtSquare.Shared.Response;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Client.Services.ProductService
{
    interface IProductService
    {
        List<Product> Products { get; set; }
        List<Product> ShopProducts { get; set; }
        Task GetProducts();

        Task GetShopItems(string id);
        Task LoadProducts();

        Task<ProductResponse.Create> AddProduct(string name, string description, double price, int width, int height, bool isAuction, Artist artist, List<Tags> tags);
        Task AddShop(ShoppingCart sc);

        Task AddAuction(DateTime deadline, double minPrice, double maxPrice, int p);
        Task UploadImageAsync(Uri sas, IBrowserFile file);
        Task AddTags(int id, Tags tag);
        Task DelShop(Product p);
        Task DelProduct(Product p);

        Task BuyItem(Product p);

    }
}
