using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Shared.Models
{
    public class Order_Product
    {
        #region Properties
        public int Id { get; set; }
        public int P_id { get; set; }
        public int O_id { get; set; } 
        #endregion
    }
}
