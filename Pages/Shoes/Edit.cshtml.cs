using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dan_Daniela_Proiect_Web.Data;
using Dan_Daniela_Proiect_Web.Models;
using System.Security.Policy;

namespace Dan_Daniela_Proiect_Web.Pages.Shoes
{
    public class EditModel : ShoeCategoriesPageModel
    {
        private readonly Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext _context;

        public EditModel(Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shoe Shoe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shoe == null)
            {
                return NotFound();
            }
            Shoe = await _context.Shoe
                     .Include(b => b.Brand)
                     .Include(b => b.ShoeCategories).ThenInclude(b => b.Category)
                     .AsNoTracking()
                     .FirstOrDefaultAsync(m => m.ID == id);

            var shoe =  await _context.Shoe.FirstOrDefaultAsync(m => m.ID == id);
            if (shoe == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Shoe);

            Shoe = shoe;
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "BrandName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var shoeToUpdate = await _context.Shoe
            .Include(i => i.Brand)
            .Include(i => i.ShoeCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (shoeToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Shoe>( shoeToUpdate, "Shoe",
            i => i.Denumire, i => i.Brand, i => i.Pret, i => i.Descriere))
            {
                UpdateShoeCategories(_context, selectedCategories, shoeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateShoeCategories(_context, selectedCategories, shoeToUpdate);
            PopulateAssignedCategoryData(_context, shoeToUpdate);
            return Page();
        }
    }
}
