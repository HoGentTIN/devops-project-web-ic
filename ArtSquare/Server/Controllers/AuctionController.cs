using ArtSquare.Server.Services.AuctionService;
using ArtSquare.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Auction>>> GetAuctions()
        {
            return Ok(await _auctionService.GetAuctions());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetAuction(int id)
        {
            return Ok(await _auctionService.GetAuction(id));
        }

        [HttpPost]
        public async Task AddAuction(Auction a)
        {
            await _auctionService.AddAuction(a);
        }
    }
}
