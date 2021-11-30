using ArtSquare.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; } = new List<Product>();
        

        public async Task<List<Product>> SetUp()
        {
            loadTxt();
            return Products;
        }

        public async Task<List<Product>> GetProducts()
        {
            loadTxt();

            return Products;

        }


        public async Task<Product> GetProduct(int id)
        {
            loadTxt();
            Product product= Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public async Task AddProduct(Product p)
        {
            var lineCount = File.ReadLines(@"Products.txt").Count();
            using StreamWriter file = new(@"Products.txt", append: true);
            await file.WriteLineAsync((lineCount+1) + ";" + p.Name + ";" + p.Price + ";/Images/art2.jpg;" + p.Width + ";" + p.Height + ";"+p.Desciption+";"+p.UploadDate.ToString("dd.MM.yyyy")+";"+p.IsAuction);
            file.Close();

            Products.Add(p);
        }

        public void loadTxt()
        {
            string[] lines = File.ReadAllLines(@"Products.txt");

            foreach (string line in lines)
            {
                string[] attributes = line.Split(";");
                string[] date = attributes[7].Split(".");
                Product p = new Product
                {
                    Id = Convert.ToInt32(attributes[0]),
                    Name = attributes[1],
                    Price = Convert.ToDouble(attributes[2]),
                    ImgPath = attributes[3],
                    Width = Convert.ToInt32(attributes[4]),
                    Height = Convert.ToInt32(attributes[5]),
                    Desciption = attributes[6],
                    UploadDate = new DateTime(Convert.ToInt16(date[2]), Convert.ToInt16(date[1]), Convert.ToInt16(date[0])),
                    IsAuction = Convert.ToBoolean(attributes[8])
                };
                Products.Add(p);
            }
        }
    }
}
