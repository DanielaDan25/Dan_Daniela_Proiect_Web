using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dan_Daniela_Proiect_Web.Models;

namespace Dan_Daniela_Proiect_Web.Data
{
    public class Dan_Daniela_Proiect_WebContext : DbContext
    {
        public Dan_Daniela_Proiect_WebContext (DbContextOptions<Dan_Daniela_Proiect_WebContext> options)
            : base(options)
        {
        }

        public DbSet<Dan_Daniela_Proiect_Web.Models.Shoe> Shoe { get; set; } = default!;

        public DbSet<Dan_Daniela_Proiect_Web.Models.Brand> Brand { get; set; }

        public DbSet<Dan_Daniela_Proiect_Web.Models.Category> Category { get; set; }

        public DbSet<Dan_Daniela_Proiect_Web.Models.Client> Client { get; set; }

        public DbSet<Dan_Daniela_Proiect_Web.Models.Comanda> Comanda { get; set; }
    }
}
