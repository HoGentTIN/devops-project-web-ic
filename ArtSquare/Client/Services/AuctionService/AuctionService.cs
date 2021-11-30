using ArtSquare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Client.Services.AuctionService
{
    public class AuctionService : IAuctionService
    {
        public List<Auction> Auctions { get; set; }

        public Task AddAuction(DateTime deadline, double minPrice, double maxPrice, Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Auction> GetAuction(int id)
        {
            throw new NotImplementedException();
        }

        public Task LoadAuctions()
        {
            throw new NotImplementedException();
        }
    }
}
