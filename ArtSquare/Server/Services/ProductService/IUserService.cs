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

        Task<Dictionary<string, string>> GetUsers(string user);

        Task AddUser(UserArt u);
        Task AddArtist(Artist a);
    }
}
