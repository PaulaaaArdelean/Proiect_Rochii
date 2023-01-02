using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Rochii.Data;
using Proiect_Rochii.Models;

namespace Proiect_Rochii.Pages.Imprumuturi
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Rochii.Data.Proiect_RochiiContext _context;

        public IndexModel(Proiect_Rochii.Data.Proiect_RochiiContext context)
        {
            _context = context;
        }

        public IList<Imprumut> Imprumut { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Imprumut != null)
            {
                Imprumut = await _context.Imprumut
                .Include(i => i.Clienta)
                .Include(i => i.Rochie).ToListAsync();
            }
        }
    }
}
