using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Models
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int P_id { get; set; }
        public int A_id { get; set; }
        public int U_id { get; set; }


    }
}
