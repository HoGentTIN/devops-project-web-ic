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
        //{
        //    new Product
        //            {
        //                Id = 1,
        //                Name = "The Scream",
        //                Price = 54.50,
        //                ImgPath = "/Images/art2.jpg",
        //                Deadline = DateTime.Now,
        //                IsAuction = false,
        //                Width = 600,
        //                Height = 400,
        //                Desciption = "This photo was taken in a small village in Istra Croatia.",

        //            },

        //    new Product
        //    {
        //        Id = 2,
        //        Name = "Rainbow",
        //        Price = 63.90,
        //        ImgPath = "example.jpg",
        //        Deadline = DateTime.Now,
        //        IsAuction = false,
        //        Width = 200,
        //        Height = 200,
        //        Desciption = "This photo was taken in a small village in Istra Croatia.",
        //    }
        //};


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
            await file.WriteLineAsync((lineCount+1) + ";" + p.Name + ";" + p.Price + ";/Images/art2.jpg;" + p.Width + ";" + p.Height + ";"+p.Desciption);

            file.Close();
            Console.WriteLine(Products.Count);
        }

        public void loadTxt()
        {
            string[] lines = File.ReadAllLines(@"Products.txt");

            foreach (string line in lines)
            {
                string[] attributes = line.Split(";");
                Product p = new Product
                {
                    Id = Convert.ToInt32(attributes[0]),
                    Name = attributes[1],
                    Price = Convert.ToDouble(attributes[2]),
                    ImgPath = attributes[3],
                    Width = Convert.ToInt32(attributes[4]),
                    Height = Convert.ToInt32(attributes[5]),
                    Desciption = attributes[6],
                };
                Products.Add(p);
            }
        }
    }
}
