using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Shared.Models
{
    public class Bet
    {
        #region Properties
        public int Id { get; set; }
        public double Amount { get; set; }
        //public int U_id { get; set; }
        public UserArt UserArt { get; set; }
        //public int P_id { get; set; } 
        public Product Product { get; set; }
        #endregion


    }
}
