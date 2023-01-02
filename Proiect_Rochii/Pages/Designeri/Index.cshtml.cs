using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Rochii.Data;
using Proiect_Rochii.Models;
using Proiect_Rochii.Models.ViewModels;

namespace Proiect_Rochii.Pages.Designeri
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Rochii.Data.Proiect_RochiiContext _context;

        public IndexModel(Proiect_Rochii.Data.Proiect_RochiiContext context)
        {
            _context = context;
        }

        public IList<Designer> Designer { get; set; } = default!;

        public DesignerIndexData DesignerData { get; set; }
        public int DesignerID { get; set; }
        public int RochieID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            DesignerData = new DesignerIndexData();
            DesignerData.Designeri = await _context.Designer
           .Include(i => i.Rochii)
           // .ThenInclude(c => c.Designer)
           .OrderBy(i => i.NumeDesigner)
           .ToListAsync();
            if (id != null)
            {
                DesignerID = id.Value;
                Designer designer = DesignerData.Designeri
                .Where(i => i.ID == id.Value).Single();
                DesignerData.Rochii = designer.Rochii;
            }

        }
    }
}
