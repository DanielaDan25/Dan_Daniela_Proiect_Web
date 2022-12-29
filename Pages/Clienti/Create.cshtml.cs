using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dan_Daniela_Proiect_Web.Data;
using Dan_Daniela_Proiect_Web.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Dan_Daniela_Proiect_Web.Pages.Clienti
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext _context;

        public CreateModel(Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Client.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
