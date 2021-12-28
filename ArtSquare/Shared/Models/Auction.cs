using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtSquare.Shared.Models
{
    public class Auction
    {
        #region Properties
        public int Id { set; get; }
        public DateTime Deadline { set; get; }
        public int HighestBetId { set; get; }
        public double MinPrice { set; get; }
        public double MaxPrice { set; get; }
        public Product Product { set; get; }
        public int ProductId { set; get; }
        #endregion
    }
}
