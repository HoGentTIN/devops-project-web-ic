using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string ImgPath { get; set; }

        public DateTime Deadline { get; set; }
        public bool IsAuction { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Desciption { get; set; }
        public string FrameDescription { get; set; }
        public int B_id { set; get; }
        public int A_id { set; get; }


    }
}
