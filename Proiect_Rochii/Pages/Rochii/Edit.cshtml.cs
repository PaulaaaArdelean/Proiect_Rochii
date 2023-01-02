using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Rochii.Data;
using Proiect_Rochii.Models;

namespace Proiect_Rochii.Pages.Rochii
{
    [Authorize(Roles = "Admin")]
    public class EditModel : CategorieRochiePageModel
    {
        private readonly Proiect_Rochii.Data.Proiect_RochiiContext _context;

        public EditModel(Proiect_Rochii.Data.Proiect_RochiiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rochie Rochie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rochie == null)
            {
                return NotFound();
            }
            Rochie = await _context.Rochie
 .Include(b => b.Designer)
 .Include(b => b.CategoriiRochii).ThenInclude(b => b.Categorie)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            var rochie =  await _context.Rochie.FirstOrDefaultAsync(m => m.ID == id);
            if (rochie == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Rochie);


            Rochie = rochie;
            ViewData["DesignerID"] = new SelectList(_context.Set<Designer>(), "NumeDesigner",
"ID");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
categorieSelectata)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var rochieToUpdate = await _context.Rochie
            .Include(i => i.Designer)
            .Include(i => i.CategoriiRochii)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (rochieToUpdate == null)
            {
                return NotFound();
            }
            
            if (await TryUpdateModelAsync<Rochie>(
            rochieToUpdate,
            "Rochie",
            i => i.Denumire, i => i.Marime,
            i => i.Pret,  i => i.DesignerID))
            {
                UpdateRochieCategorii(_context, categorieSelectata, rochieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateRochieCategorii(_context, categorieSelectata, rochieToUpdate);
            PopulateAssignedCategoryData(_context, rochieToUpdate);
            return Page();
        }
    }
}
