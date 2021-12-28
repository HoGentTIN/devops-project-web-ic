using ArtSquare.Server.Services.ProductService;
using ArtSquare.Shared.Models;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArtSquare.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ManagementApiClient _managementApiClient;
        public ArtistController(IUserService userService, ManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
            _userService = userService;
        }
        [Authorize]
        [HttpPost]
        public async Task AddArtist(Artist a)
        {
            await _userService.AddArtist(a);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(string id)
        {
            return Ok(await _userService.GetArtist(id));
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(int id)
        {
            return Ok(await _userService.GetArtistById(id));
        }

    }
}
