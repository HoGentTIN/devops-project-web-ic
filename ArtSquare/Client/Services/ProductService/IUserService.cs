using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Client.Services.ProductService
{
    interface IUserService
    {
        Task<Dictionary<string, string>> GetUser();

        Task<bool> CheckIfUserExist();

        Task AddUser(string userid, string firstname, string lastname, string email);
        Task AddArtist(string userid, string firstname, string lastname, string email);
    }
}
