using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Rochii.Data;
using Proiect_Rochii.Models;

namespace Proiect_Rochii.Pages.Rochii
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Rochii.Data.Proiect_RochiiContext _context;

        public DeleteModel(Proiect_Rochii.Data.Proiect_RochiiContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Rochie Rochie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rochie == null)
            {
                return NotFound();
            }

            var rochie = await _context.Rochie.FirstOrDefaultAsync(m => m.ID == id);

            if (rochie == null)
            {
                return NotFound();
            }
            else 
            {
                Rochie = rochie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rochie == null)
            {
                return NotFound();
            }
            var rochie = await _context.Rochie.FindAsync(id);

            if (rochie != null)
            {
                Rochie = rochie;
                _context.Rochie.Remove(Rochie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
