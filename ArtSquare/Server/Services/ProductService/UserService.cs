using ArtSquare.Server.Data;
using ArtSquare.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Services.ProductService
{
    public class UserService : IUserService
    {
        private readonly ArtSquareServerContext _context;
        public UserService(ArtSquareServerContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckIfUserExist(string id)
        {
            UserArt user= await _context.UserArts.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
