using ArtSquare.Shared.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Services.ProductService
{
    public interface IUserService
    {
        Task<bool> CheckIfUserExist(string id);
        Task<bool> AssignRole(string id);

        Task<bool> BlockUser(string id);

        Task<Dictionary<string, string>> GetUsers(string user);

        Task AddUser(UserArt u);
        Task AddArtist(Artist a);
        Task<Artist> GetArtist(string id);

        Task<UserArt> GetUserById(string id);
        Task<Artist> GetArtistByArtistId(string id);

        Task<Artist> GetArtistById(int id);

        Task<Uri> GetUri(int id);

        Task UpdateDesc(Artist artist);
        Task UpdateBank(Artist artist);



    }
}
