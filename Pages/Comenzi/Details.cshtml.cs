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
    public class DetailsModel : PageModel
    {
        private readonly Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext _context;

        public DetailsModel(Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext context)
        {
            _context = context;
        }

      public Comanda Comanda { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Comanda == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comanda.FirstOrDefaultAsync(m => m.ID == id);
            if (comanda == null)
            {
                return NotFound();
            }
            else 
            {
                Comanda = comanda;
            }
            return Page();
        }
    }
}
