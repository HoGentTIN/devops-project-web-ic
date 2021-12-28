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
        [HttpGet("{id}")]
        public async Task<ActionResult<UserArt>> GetUserById(string id)
        {
            ActionResult<UserArt> u = Ok(await _userService.GetUserById(id));
            return u;
        }
        
        [Authorize]
        [HttpGet("/artistById/{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(string id)
        {
            ActionResult<Artist> u = Ok(await _userService.GetArtistByArtistId(id));
            return u;
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
                City = x.NickName,
                Street = x.UserId,
            });
        }
        [Authorize]
        [HttpGet("GetUri/{id}")]
        public async Task<Uri> GetUri(int id)
        {
            return await _userService.GetUri(id);
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
        [HttpGet("AssignRole")]
        public async Task<ActionResult<bool>> AssignRole()
        {
            string user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (user == null || user.Equals(""))
            {
                return true;
            }
            return Ok(await _userService.AssignRole(user));
        }

        [Authorize]
        [HttpGet("Block/{id}")]
        public async Task<ActionResult<bool>> BlockUser(string id)
        {
            string user = id;
            if (user == null || user.Equals(""))
            {
                return true;
            }

            return Ok(await _userService.BlockUser(user));


        }
        [Authorize]
        [HttpPost]
        public async Task AddUser2(UserArt u)
        {
            await _userService.AddUser(u);
        }

        [Authorize]
        [HttpPut("UpdateDesc")]
        public async Task AddUser(Artist u)
        {
            await _userService.UpdateDesc(u);
        }
        [Authorize]
        [HttpPut("UpdateBank")]
        public async Task UpdateBank(Artist u)
        {
            await _userService.UpdateBank(u);
        }
    }
}