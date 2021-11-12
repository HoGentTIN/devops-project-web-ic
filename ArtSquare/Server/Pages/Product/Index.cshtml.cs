using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtSquare.Server.Data;
using ArtSquare.Server.Models;

namespace ArtSquare.Server.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ArtSquare.Server.Data.ArtSquareServerContext _context;

        public IndexModel(ArtSquare.Server.Data.ArtSquareServerContext context)
        {
            _context = context;
        }

        public IList<ArtSquare.Server.Models.Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
