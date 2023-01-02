



using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    public class CreateModel : CategorieRochiePageModel
    {
        private readonly Proiect_Rochii.Data.Proiect_RochiiContext _context;

        public CreateModel(Proiect_Rochii.Data.Proiect_RochiiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DesignerID"] = new SelectList(_context.Set<Designer>(), "ID", "NumeDesigner");
            var rochie = new Rochie();
            rochie.CategoriiRochii = new List<CategorieRochie>();
            PopulateAssignedCategoryData(_context, rochie);

            return Page();
        }

        [BindProperty]
        public Rochie Rochie { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD


        public async Task<IActionResult> OnPostAsync(string[] categorieSelectata)
        {
            var rochieNoua = new Rochie();
            if (categorieSelectata != null)
            {
                rochieNoua.CategoriiRochii = new List<CategorieRochie>();
                foreach (var cat in categorieSelectata)
                {
                    var catToAdd = new CategorieRochie
                    {
                        CategorieID = int.Parse(cat)
                    };
                    rochieNoua.CategoriiRochii.Add(catToAdd);
                }
            }
            Rochie.CategoriiRochii = rochieNoua.CategoriiRochii;
            _context.Rochie.Add(Rochie);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, rochieNoua);
            return Page();
        }

    }
}
