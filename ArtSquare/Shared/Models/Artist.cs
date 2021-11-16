using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Shared.Models
{
    public class Artist
    {
        #region properties
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public string Bank { get; set; }
        public string Nationality { get; set; }
        public bool IsYoungArtist { get; set; }
        public bool IsConformed { get; set; } 
        #endregion



    }
}
