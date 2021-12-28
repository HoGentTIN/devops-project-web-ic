using ArtSquare.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtSquare.Server.Services.ProductService
{
    public interface ITagsService
    {
        Task<List<Tags>> SetUp();
    }
}
