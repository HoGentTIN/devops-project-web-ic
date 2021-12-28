using ArtSquare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Services.AuctionService
{
    public interface IAuctionService
    {
        Task<List<Auction>> GetAuctions();
        Task<Auction> GetAuction(int id);

        Task AddAuction(Auction a);
    }
}
