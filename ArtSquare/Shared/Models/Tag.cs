using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Shared.Models
{
    public class Tag
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; } 
        public List<Product> Products { get; set; }
        #endregion
    }
}
