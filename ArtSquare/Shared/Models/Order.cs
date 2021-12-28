using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Shared.Models
{
    public class Order
    {
        #region Properties
        public int Id { get; set; }
        public string DestinationStreet { get; set; }
        public string DestinationCity { get; set; }
        public int DestinationZipcpde { get; set; }
        public string DestinationCountry { get; set; }
        public double TotalPrice { get; set; }
        public UserArt UserArt { get; set; }
        public int UserArtId { get; set; }

        public List<Product> Products { get; set; }

        #endregion

    }
}
