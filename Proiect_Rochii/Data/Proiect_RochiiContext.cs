using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Rochii.Models;

namespace Proiect_Rochii.Data
{
    public class Proiect_RochiiContext : DbContext
    {
        public Proiect_RochiiContext (DbContextOptions<Proiect_RochiiContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Rochii.Models.Rochie> Rochie { get; set; } = default!;

        public DbSet<Proiect_Rochii.Models.Designer> Designer { get; set; }

        public DbSet<Proiect_Rochii.Models.Categorie> Categorie { get; set; }

        public DbSet<Proiect_Rochii.Models.Clienta> Clienta { get; set; }

        public DbSet<Proiect_Rochii.Models.Imprumut> Imprumut { get; set; }
    }
}
