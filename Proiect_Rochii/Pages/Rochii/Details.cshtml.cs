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

    public class DetailsModel : PageModel
    {
        private readonly Proiect_Rochii.Data.Proiect_RochiiContext _context;

        public DetailsModel(Proiect_Rochii.Data.Proiect_RochiiContext context)
        {
            _context = context;
        }

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
    }
}
