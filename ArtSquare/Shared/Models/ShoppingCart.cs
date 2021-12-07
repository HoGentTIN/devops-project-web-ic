using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtSquare.Shared.Models
{
    public class ShoppingCart
    {

        #region Properties
        public int Id { get; set; }
        public List<Product> Products {get; set;}
        public UserArt UserArt { get; set; }
        public int UserArtId { get; set; }
        public double TotalPrice { get; set; }
        #endregion
    }
}
