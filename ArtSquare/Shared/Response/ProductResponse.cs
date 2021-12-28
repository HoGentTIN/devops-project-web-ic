using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtSquare.Shared.Response
{
    public static class ProductResponse
    {
        // Other responses
        public class Create
        {
            public int ProductId { get; set; }
            public Uri UploadUri { get; set; }
        }
    }
}
