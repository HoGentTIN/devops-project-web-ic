using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Models
{
    public class Bet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public double amount { get; set; }
        public int U_id { get; set; }
        public int P_id { get; set; }


    }
}
