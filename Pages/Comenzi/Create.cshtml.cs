using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dan_Daniela_Proiect_Web.Data;
using Dan_Daniela_Proiect_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Dan_Daniela_Proiect_Web.Pages.Comenzi
{
    public class CreateModel : PageModel
    {
        private readonly Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext _context;

        public CreateModel(Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var shoeList = _context.Shoe
            .Include(b => b.Brand)
            .Select(x => new
            {
                 x.ID,
                 ShoeFullName = x.Denumire + "  " + x.Brand + " " });

            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
        ViewData["ShoeID"] = new SelectList(_context.Shoe, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Comanda Comanda { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comanda.Add(Comanda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
