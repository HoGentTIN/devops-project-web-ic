using ArtSquare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ArtSquare.Client
{
    public class PublicClient
    {

        public List<Product> Products { get; set; } = new List<Product>();

        public List<Auction> Auctions { get; set; } = new List<Auction>();
        public Product DetailProduct { get; set; }=new Product();

        public Auction DetailAuction { get; set; } = new Auction();
        public Artist DetailArtist { get; set; } =new Artist();


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
        public async Task LoadAuctions()
        {
            Auctions = await _client.GetFromJsonAsync<List<Auction>>("api/Product/Auctions");
        }
        public async Task LoadTags()
        {
            Tags = await _client.GetFromJsonAsync<List<Tags>>("api/Tags/SetUp");
        }

        public async Task GetProduct(int id)
        {
            DetailProduct = await _client.GetFromJsonAsync<Product>($"api/Product/{id}");
            Console.WriteLine();
        }

        public async Task GetAuction(int id)
        {
            DetailAuction = await _client.GetFromJsonAsync<Auction>($"api/Product/Auction/{id}");
        }



        public async Task GetArtist(int id)
        {
            Artist a = await _client.GetFromJsonAsync<Artist>($"Artist/ById/{id}");
            DetailProduct.Artist = a;
            DetailArtist = a;
            Console.WriteLine(DetailProduct.Artist.Firstname);
        }
    }
}
