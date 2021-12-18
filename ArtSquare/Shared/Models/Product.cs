using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Shared.Models
{
    public class Product
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }

        public string ImgPath { get; set; }
        public DateTime UploadDate { get; set; }
        public bool IsAuction { get; set; }

        public double Width { get; set; }
        public double Height { get; set; }
        public string Desciption { get; set; }
        //public int BetId { set; get; }
        //public Bet Bet { set; get; }
        public Artist Artist { set; get; }
        public int ArtistId { set; get; }
        public List<Tags> Tags { set; get; }
        public List<Order> Orders { set; get; }
        public List<ShoppingCart> ShoppingCarts { set; get; }

        public override string ToString()
        {
            return Id + "; " + Name + "; ";
        }
        #endregion


    }
}
