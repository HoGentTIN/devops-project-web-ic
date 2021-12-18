using ArtSquare.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ArtSquare.Client
{
    public class PublicClient
    {

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Tags> Tags { get; set; } = new List<Tags>();

        public HttpClient _client;

        public PublicClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task LoadProducts()
        {
            Products = await _client.GetFromJsonAsync<List<Product>>("api/Product/SetUp");
        }

        public async Task LoadTags()
        {
            Tags = await _client.GetFromJsonAsync<List<Tags>>("api/Tags/SetUp");
        }
    }
}
