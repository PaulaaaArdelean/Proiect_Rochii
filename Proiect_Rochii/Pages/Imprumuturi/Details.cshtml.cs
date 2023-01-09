﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Rochii.Data.Proiect_RochiiContext _context;

        public DetailsModel(Proiect_Rochii.Data.Proiect_RochiiContext context)
        {
            _context = context;
        }

      public Imprumut Imprumut { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Imprumut == null)
            {
                return NotFound();
            }

            var imprumut = await _context.Imprumut.Include(b => b.Clienta).Include(b =>b.Rochie).FirstOrDefaultAsync(m=>m.ID == id);
            if (imprumut == null)
            {
                return NotFound();
            }
            else 
            {
                Imprumut = imprumut;
            }
            return Page();
        }
    }
}
