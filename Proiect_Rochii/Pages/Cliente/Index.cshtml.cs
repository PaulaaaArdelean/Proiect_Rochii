using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Rochii.Data;
using Proiect_Rochii.Models;

namespace Proiect_Rochii.Pages.Cliente
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Rochii.Data.Proiect_RochiiContext _context;

        public IndexModel(Proiect_Rochii.Data.Proiect_RochiiContext context)
        {
            _context = context;
        }

        public IList<Clienta> Clienta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Clienta != null)
            {
                Clienta = await _context.Clienta.ToListAsync();
            }
        }
    }
}
