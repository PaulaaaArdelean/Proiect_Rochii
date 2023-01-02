using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Rochii.Data;
using Proiect_Rochii.Models;

namespace Proiect_Rochii.Pages.Rochii
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Rochii.Data.Proiect_RochiiContext _context;

        public IndexModel(Proiect_Rochii.Data.Proiect_RochiiContext context)
        {
            _context = context;
        }

        public IList<Rochie> Rochie { get; set; } = default!;
        public RochieData RochieD { get; set; }
        public int RochieID { get; set; }
        public int CategorieID { get; set; }

        public string SortarePret { get; set; }
        // public string SortareDesigner { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID, string ordineSortare, string searchString)
        {
            RochieD = new RochieData();

            SortarePret = String.IsNullOrEmpty(ordineSortare) ? "pret_desc" : "";
          //  SortareDesigner = String.IsNullOrEmpty(ordineSortare) ? "designer_desc" : "";

            CurrentFilter = searchString;

            RochieD.Rochii = await _context.Rochie
            .Include(b => b.Designer)
            .Include(b => b.CategoriiRochii)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            //era order by title
            .OrderBy(b => b.Pret)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                RochieD.Rochii = RochieD.Rochii.Where(s => s.Designer.NumeDesigner.Contains(searchString)

               || s.Designer.NumeDesigner.Contains(searchString)
               || s.Denumire.Contains(searchString));

                if (id != null)
                {
                    RochieID = id.Value;
                    Rochie rochie = RochieD.Rochii
                    .Where(i => i.ID == id.Value).Single();
                    RochieD.Categorii = rochie.CategoriiRochii.Select(s => s.Categorie);
                }
                switch (ordineSortare)
                {
                    case "pret_desc":
                        RochieD.Rochii = RochieD.Rochii.OrderByDescending(s =>   s.Pret);
                        break;
                    //  case "designer_desc":
                    //    RochieD.Rochii = RochieD.Rochii.OrderByDescending(s =>
                    //  s.Designer.NumeDesigner);
                    //   break;


                }
            }

        }
    }
}
