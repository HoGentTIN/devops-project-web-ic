using ArtSquare.Server.Services.ProductService;
using ArtSquare.Shared.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serialization.Json;
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
        private readonly IUserService _userService;

       


        private readonly ManagementApiClient _managementApiClient;



        public UserController(IUserService userService, ManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
            _userService = userService;
            

        }

        [Authorize]
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

        [Authorize]
        [HttpGet("id")]
        public async Task<ActionResult<Dictionary<string, string>>> GetUser()
        {
            string user = "";
            try
            {
                user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            
            return Ok(await _userService.GetUsers(user));  
        }

        [Authorize]
        [HttpGet("exist")]
        public async Task<ActionResult<bool>> CheckIfUserExist()
        {
            string user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if(user==null || user.Equals(""))
            {
                return true;
            }

            return Ok(await _userService.CheckIfUserExist(user));
            
            
        }

        [Authorize]
        [HttpPost]
        public async Task AddUser(UserArt u)
        {
            await _userService.AddUser(u);
        }
    }
}