using ArtSquare.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArtSquare.Server.Data;
using ArtSquare.Shared.Response;

namespace ArtSquare.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ArtSquareServerContext _context;
        private readonly IStorageService storageService;
        public ProductService(ArtSquareServerContext context, IStorageService storageService)
        {
            _context = context;
            this.storageService = storageService;
        }
        //public List<Product> Products { get; set; } = new List<Product>();
        

        public async Task<List<Product>> SetUp()
        {
            return await _context.Products.Include(a => a.Artist).ToListAsync();
        }

        public async Task<List<Auction>> SetUpAuction()
        {
            return await _context.Auctions.Include(a => a.Product).ToListAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await _context.Products
                .Include(p => p.Artist)
                .Include(p => p.Tags)
                .ToListAsync();

            foreach (var p in products)
            {
                foreach (var t in p.Tags)
                {
                    t.Products = null;
                }
            }
            return products;
        }

        public async Task<List<Product>> GetShopItems(string id)
        {
            List<ShoppingCart> shop = await _context.ShoppingCarts.Include(a => a.UserArt).ToListAsync();
            List<ShoppingCart> shop2 = await _context.ShoppingCarts.Include(a => a.Product).ToListAsync();
            List<Product> products = new List<Product>();
            foreach(var s in shop)
            {
                foreach(var item in shop2)
                {
                    if(s.Id == item.Id)
                    {
                        s.Product = item.Product;
                    }
                }
                if(s.UserArt.UserId.Equals(id))
                {
                    products.Add(s.Product);
                }
            }
            return products;
        }


        public async Task<Product> GetProduct(int id)
        {
            var bTemp = _context.Products.Where(b => b.Id==id)
            .Select(b => new
            {
                b,
                Tags = b.Tags
            })
            .ToList();
            foreach(var x in bTemp)
            {
                foreach(var y in x.Tags)
                {
                    if(x.b.Tags==null)
                    {
                        x.b.Tags = new List<Tags>();
                    }
                    x.b.Tags.Add(y);
                }
            }
            var products = bTemp.Select(x => x.b).First();
            return products;
            //var product = await _context.Products.Where(a => a.Id == id).FirstAsync();
            //return product;
        }
        public async Task<Auction> GetAuction(int id)
        {

            var auction = await _context.Auctions.Where(a => a.ProductId == id).FirstAsync();
            return auction;
        }

        public async Task<ProductResponse.Create> AddProduct(Product p)
        {
            var imageFilename = Guid.NewGuid().ToString();
            var imagePath = $"{storageService.StorageBaseUri}{imageFilename}";
            p.ImgPath = imagePath;
            List<Tags> tags = p.Tags;
            p.Tags = null;
            ProductResponse.Create response = new();
            await _context.AddAsync<Product>(p);
            _context.SaveChanges();
            foreach (var tag in tags)
            {
                var product = await _context.Products.Where(a => a.Id == p.Id).FirstAsync();
                if (product.Tags == null)
                {
                    product.Tags = new List<Tags>();
                }

                product.Tags.Add(tag);
                _context.SaveChanges();
            }
            var uploadUri = storageService.CreateUploadUri(imageFilename);
            response.UploadUri = uploadUri;
            response.ProductId = p.Id;
            return response;
        }
        public async Task DelProduct(Product p)
        {
            Product copy = p;
            await DelShopAll(copy);
            _context.Remove<Product>(p);
            _context.SaveChanges();
        }
        public async Task DelShopAll(Product p)
        {
            List<ShoppingCart> shop = await _context.ShoppingCarts.Include(a => a.Product).ToListAsync();
            List<ShoppingCart> shop2 = await _context.ShoppingCarts.Include(a => a.UserArt).ToListAsync();
            foreach (var s in shop)
            {
                foreach (var s2 in shop2)
                {
                    if (s.Id == s2.Id)
                    {
                        s.UserArt = s2.UserArt;
                    }
                }
            }


            foreach (var s in shop)
            {
                if (s.Product.Id == p.Id)
                {
                    s.Product = null;
                    s.UserArt = null;
                    _context.Remove<ShoppingCart>(s);
                    _context.SaveChanges();
                }
            }
        }
        public async Task DelShop(Product p)
        {
            string user = p.Desciption;
            List<ShoppingCart> shop = await _context.ShoppingCarts.Include(a => a.Product).ToListAsync();
            List<ShoppingCart> shop2 = await _context.ShoppingCarts.Include(a => a.UserArt).ToListAsync();
            foreach(var s in shop)
            {
                foreach(var s2 in shop2)
                {
                    if(s.Id == s2.Id)
                    {
                        s.UserArt = s2.UserArt;
                    }
                }
            }
            

            foreach (var s in shop)
            {
                if(s.Product.Id==p.Id && s.UserArt.UserId.Equals(user))
                {
                    s.Product = null;
                    s.UserArt = null;
                    _context.Remove<ShoppingCart>(s);
                    _context.SaveChanges();
                }
            }
        }

        public async Task BuyItem(Product p)
        {
            string user = p.Desciption;
            List<Product> products = await _context.Products.Where(a => a.Id ==p.Id).ToListAsync();
            foreach (var s in products)
            {
                s.BoughtBy = user;
                _context.Update<Product>(s);
                _context.SaveChanges();

            }
        }

            public async Task AddShop(ShoppingCart sc)
        {
            sc.TotalPrice += sc.Product.Price;
            Product p = sc.Product;
            sc.Product = null;
            sc.UserArtId = sc.UserArt.Id;
            sc.UserArt = null;
            await _context.AddAsync<ShoppingCart>(sc);
            _context.SaveChanges();
            sc.Product = p;
            sc.Product.Tags = null;
            _context.SaveChanges();


        }

        public async Task AddAuction(Auction a)
        {
            await _context.AddAsync<Auction>(a);
            _context.SaveChanges();
        }
    }
}
