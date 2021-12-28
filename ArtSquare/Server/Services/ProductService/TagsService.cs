using ArtSquare.Server.Data;
using ArtSquare.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtSquare.Server.Services.ProductService
{
    public class TagsService : ITagsService
    {
        private readonly ArtSquareServerContext _context;
        public TagsService(ArtSquareServerContext context)
        {
            _context = context;
        }
        

        async Task<List<Tags>> ITagsService.SetUp()
        {
            return await _context.Tags.ToListAsync();
        }
    }
}
