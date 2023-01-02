using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Rochii.Data;
using Proiect_Rochii.Models;

namespace Proiect_Rochii.Pages.Imprumuturi
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Rochii.Data.Proiect_RochiiContext _context;

        public CreateModel(Proiect_Rochii.Data.Proiect_RochiiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var listaRochii = _context.Rochie
                        .Include(b => b.Designer)
                        .Select(x => new
                        {
                            x.ID,
                            NumeleIntregAlRochiei = x.Denumire + "-" + x.Designer.NumeDesigner
                        });

            ViewData["ClientaID"] = new SelectList(_context.Clienta, "ID", "NumeIntreg");
            ViewData["RochieID"] = new SelectList(listaRochii, "ID", "NumeleIntregAlRochiei");
            return Page();
        }

        [BindProperty]
        public Imprumut Imprumut { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Imprumut.Add(Imprumut);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
