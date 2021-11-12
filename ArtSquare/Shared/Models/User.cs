using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Server.Models
{
    public class User
    {
        #region properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        #endregion





    }
}
