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
    public class DeleteModel : PageModel
    {
        private readonly ArtSquare.Server.Data.ArtSquareServerContext _context;

        public DeleteModel(ArtSquare.Server.Data.ArtSquareServerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FindAsync(id);

            if (Product != null)
            {
                _context.Product.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
