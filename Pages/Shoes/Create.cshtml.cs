using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dan_Daniela_Proiect_Web.Data;
using Dan_Daniela_Proiect_Web.Models;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;

namespace Dan_Daniela_Proiect_Web.Pages.Shoes
{
    public class CreateModel : ShoeCategoriesPageModel
    {
        private readonly Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext _context;

        public CreateModel(Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "BrandName");
            var shoe = new Shoe();
            shoe.ShoeCategories = new List<ShoeCategory>();
            PopulateAssignedCategoryData(_context, shoe);
            return Page();
        }

        [BindProperty]
        public Shoe Shoe { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newShoe = Shoe;
            if (selectedCategories != null)
            {
                newShoe.ShoeCategories = new List<ShoeCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ShoeCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newShoe.ShoeCategories.Add(catToAdd);
                }
            }
            /* if (await TryUpdateModelAsync<Book>(
             newBook,
             "Book",
             i => i.Title, i => i.Author,
             i => i.Price, i => i.PublishingDate, i => i.PublisherID))
             {*/
            _context.Shoe.Add(newShoe);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            

            PopulateAssignedCategoryData(_context, newShoe);
            return Page();
        }
    }
}