using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSquare.Shared.Models
{
    public class Review
    {
        #region Properties
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Product Product { get; set; }
        public int? ProductId { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public UserArt UserArt { set; get; }
        public int UserArtId { set; get; }
        #endregion


    }
}
