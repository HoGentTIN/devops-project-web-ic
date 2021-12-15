using ArtSquare.Shared.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArtSquare.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ManagementApiClient _managementApiClient;



        public UserController(ManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }

        [HttpGet]
        public async Task<IEnumerable<UserArt>> GetUsers()
        {
            var users = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo());
            return users.Select(x => new UserArt
            {
                Email = x.Email,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                Blocked = x.Blocked ?? false,
            });
        }

        [HttpGet("id")]
        public async Task<String> GetUser()
        {
            string user = "";
            foreach(var item in User.Claims.ToList())
            {
                user += item.ToString();
            }
            return user;
            
        }
    }
}