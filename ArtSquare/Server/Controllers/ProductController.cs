using ArtSquare.Server.Services.ProductService;
using ArtSquare.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _productService.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProduct(int id)
        {
            return Ok(await _productService.GetProduct(id));
        }

        [HttpPost]
        public async Task AddProduct(Product p)
        {
            await _productService.AddProduct(p);
        }
    }
}
