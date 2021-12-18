using ArtSquare.Server.Services.ProductService;
using ArtSquare.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtSquare.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _tagsService;

        public TagsController(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }

        [HttpGet("SetUp")]
        public async Task<ActionResult<List<Tags>>> SetUp()
        {
            return Ok(await _tagsService.SetUp());
        }
    }
}
