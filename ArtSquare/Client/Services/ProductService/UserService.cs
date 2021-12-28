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

        public async Task<Artist> GetArtist(string userid)
        {
            return await _http.GetFromJsonAsync<Artist>($"artist/{userid}");
        }

        public async Task<UserArt> GetUserById(string userid)
        {
            return await _http.GetFromJsonAsync<UserArt>($"user/{userid}");
        }

        public async Task<Artist> GetArtistById(string userid)
        {
            return await _http.GetFromJsonAsync<Artist>($"user/artistById/{userid}");
        }

        public async Task<Dictionary<string, string>> GetUser()
        {
            return await _http.GetFromJsonAsync<Dictionary<string, string>>($"user/id");
        }

        public async Task AssignRole()
        {
            await _http.GetFromJsonAsync<bool>($"user/AssignRole");
        }
        public async Task BlockUser(string id)
        {
            await _http.GetFromJsonAsync<bool>($"user/Block/{id}");
        }

        public async Task<Uri> GetUri(int id)
        {
            return await _http.GetFromJsonAsync<Uri>($"user/GetUri/{id}");
        }

        public async Task UpdateDesc(Artist artist)
        {
            await _http.PutAsJsonAsync("user/UpdateDesc", artist);
        }
        public async Task UpdateBank(Artist artist)
        {
            await _http.PutAsJsonAsync("user/UpdateBank", artist);
        }


    }
}
