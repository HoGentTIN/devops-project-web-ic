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
    public class DetailsModel : PageModel
    {
        private readonly ArtSquare.Server.Data.ArtSquareServerContext _context;

        public DetailsModel(ArtSquare.Server.Data.ArtSquareServerContext context)
        {
            _context = context;
        }

        public ArtSquare.Server.Models.Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
