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
        public async Task<string> GetUser()
        {
            return await _http.GetFromJsonAsync<string>($"user/id");
        }
    }
}
