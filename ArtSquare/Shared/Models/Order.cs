using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string DestinationStreet { get; set; }
        public string DestinationCity { get; set; }
        public int DestinationZipcpde { get; set; }
        public string DestinationCountry { get; set; }
        public double TotalPrice { get; set; }
        public int U_id { get; set; }

    }
}
