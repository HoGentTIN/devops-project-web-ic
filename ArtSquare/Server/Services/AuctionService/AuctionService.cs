using ArtSquare.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Services.AuctionService
{
    public class AuctionService : IAuctionService
    {
        public List<Auction> Auctions { get; set; } = new List<Auction>();
        public async Task AddAuction(Auction a)
        {
            var lineCount = File.ReadLines(@"Auctions.txt").Count();
            using StreamWriter file = new(@"Auctions.txt", append: true);
            await file.WriteLineAsync((lineCount + 1) + ";" + a.Deadline.ToString("dd.MM.yyyy") + ";" + a.MinPrice + ";" + a.MaxPrice);
            file.Close();

            Auctions.Add(a);
        }

        public Task<Auction> GetAuction(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Auction>> GetAuctions()
        {
            throw new NotImplementedException();
        }

        public void loadTxt()
        {


            string[] lines = File.ReadAllLines(@"Auctions.txt");

            foreach (string line in lines)
            {
                string[] attributes = line.Split(";");
                string[] date = attributes[0].Split(".");
                Auction a = new Auction
                {
                    Deadline = new DateTime(Convert.ToInt16(date[2]), Convert.ToInt16(date[1]), Convert.ToInt16(date[0])),
                    MinPrice = Convert.ToDouble(attributes[1]),
                    MaxPrice = Convert.ToDouble(attributes[2]),
                };
                Auctions.Add(a);
            }
        }
    }
}
