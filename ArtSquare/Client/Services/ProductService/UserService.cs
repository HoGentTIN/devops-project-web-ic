using ArtSquare.Shared.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ArtSquare.Client.Services.ProductService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;


        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task AddUser(string userid, string firstname, string lastname, string email)
        {
            var postBody = new UserArt
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                UserId = userid
            };
            await _http.PostAsJsonAsync<UserArt>("User", postBody);
        }

        public async Task AddArtist(string userid, string firstname, string lastname, string email)
        {
            var postBody = new Artist
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                ArtistId = userid
            };
            await _http.PostAsJsonAsync<Artist>("Artist", postBody);
        }

        public async Task<bool> CheckIfUserExist()
        {
            return await _http.GetFromJsonAsync<bool>($"user/exist");
        }

        public async Task<Dictionary<string, string>> GetUser()
        {
            return await _http.GetFromJsonAsync<Dictionary<string, string>>($"user/id");
        }


    }
}
