using ArtSquare.Server.Services.ProductService;
using ArtSquare.Shared.Models;
using ArtSquare.Shared.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArtSquare.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("SetUp")]
        public async Task<ActionResult<List<Product>>> SetUp()
        {
            return Ok(await _productService.SetUp());
        }
        [HttpGet("Auctions")]
        public async Task<ActionResult<List<Auction>>> SetUpAuction()
        {
            return Ok(await _productService.SetUpAuction());
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] bool android = false)
        {
            if (android)
            {
                return Ok(new { body = await _productService.GetProducts() });
            }
            return Ok(await _productService.GetProducts());
        }

        [HttpGet("ShopItems/{id}")]
        public async Task<ActionResult<List<Product>>> GetShopItems(string id)
        {
            return Ok(await _productService.GetShopItems(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await _productService.GetProduct(id));
        }

        [HttpGet("Auction/{id}")]
        public async Task<ActionResult<Auction>> GetAuction(int id)
        {
            return Ok(await _productService.GetAuction(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProductResponse.Create>> AddProduct(Product p)
        {
            return Ok(await _productService.AddProduct(p));
        }
        [Authorize]
        [HttpPost("DelShop")]
        public async Task DelShop(Product p)
        {
            string user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            p.Desciption = user;
            await _productService.DelShop(p);
        }
        [Authorize]
        [HttpPost("DelProduct")]
        public async Task DelProduct(Product p)
        {
            
            await _productService.DelProduct(p);
        }
        [Authorize]
        [HttpPost ("AddShop")]
        public async Task AddShop(ShoppingCart sc)
        {
            
            
            await _productService.AddShop(sc);
        }

        [Authorize]
        [HttpPut("BuyItem")]
        public async Task BuyItem(Product p)
        {
            string user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            p.Desciption = user;
            await _productService.BuyItem(p);
        }

        [Authorize]
        [HttpPost("Auction")]
        public async Task AddAuction(Auction a)
        {
            await _productService.AddAuction(a);
        }
    }
}
