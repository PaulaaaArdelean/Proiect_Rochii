using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Rochii.Data;
using Proiect_Rochii.Models;

namespace Proiect_Rochii.Pages.Designeri
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Rochii.Data.Proiect_RochiiContext _context;

        public DetailsModel(Proiect_Rochii.Data.Proiect_RochiiContext context)
        {
            _context = context;
        }

      public Designer Designer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Designer == null)
            {
                return NotFound();
            }

            var designer = await _context.Designer.FirstOrDefaultAsync(m => m.ID == id);
            if (designer == null)
            {
                return NotFound();
            }
            else 
            {
                Designer = designer;
            }
            return Page();
        }
    }
}
