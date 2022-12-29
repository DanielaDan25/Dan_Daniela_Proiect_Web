using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dan_Daniela_Proiect_Web.Data;
using Dan_Daniela_Proiect_Web.Models;

namespace Dan_Daniela_Proiect_Web.Pages.Comenzi
{
    public class IndexModel : PageModel
    {
        private readonly Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext _context;

        public IndexModel(Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext context)
        {
            _context = context;
        }

        public IList<Comanda> Comanda { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Comanda != null)
            {
                Comanda = await _context.Comanda
                .Include(c => c.Shoe)
                           .ThenInclude(b=> b.Brand )
                .Include(c => c.Client).ToListAsync();
            }
        }
    }
}
