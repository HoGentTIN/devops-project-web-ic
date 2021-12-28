using ArtSquare.Shared.Models;
using ArtSquare.Shared.Response;
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
        Task<List<Auction>> SetUpAuction();
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetShopItems(string id);
        Task<Product> GetProduct(int id);

        Task<Auction> GetAuction(int id);

        Task<ProductResponse.Create> AddProduct(Product p);

        Task AddShop(ShoppingCart sc);

        Task AddAuction(Auction a);

        Task DelShop(Product p);
        Task DelProduct(Product p);
        Task BuyItem(Product p);



    }
}
