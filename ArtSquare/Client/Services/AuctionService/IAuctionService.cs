using ArtSquare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Client.Services.AuctionService
{
    interface IAuctionService
    {
        List<Auction> Auctions { get; set; }
        Task LoadAuctions();
        Task<Auction> GetAuction(int id);

        Task AddAuction(DateTime deadline, double minPrice, double maxPrice, Product product);
    }
}

