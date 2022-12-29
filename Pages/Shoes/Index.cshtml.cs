using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dan_Daniela_Proiect_Web.Data;
using Dan_Daniela_Proiect_Web.Models;

namespace Dan_Daniela_Proiect_Web.Pages.Shoes
{
    public class IndexModel : PageModel
    {
        private readonly Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext _context;

        public IndexModel(Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext context)
        {
            _context = context;
        }

        public IList<Shoe> Shoe { get; set; }

        public ShoeData ShoeD { get; set; }
        public int ShoeID { get; set; }
        public int CategoryID { get; set; }
        public string DenumireSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            ShoeD = new ShoeData();
            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";

            CurrentFilter = searchString;


            ShoeD.Shoes = await _context.Shoe
            .Include(b => b.Brand)
            .Include(b => b.ShoeCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ShoeD.Shoes = ShoeD.Shoes.Where(s => s.Denumire.Contains(searchString)

               || s.Brand.BrandName.Contains(searchString)
               || s.Denumire.Contains(searchString));

                if (id != null)
                {
                    ShoeID = id.Value;
                    Shoe shoe = ShoeD.Shoes
                    .Where(i => i.ID == id.Value).Single();
                    ShoeD.Categories = shoe.ShoeCategories.Select(s => s.Category);
                }
                switch (sortOrder)
                {
                    case "denumire_desc":
                        ShoeD.Shoes = ShoeD.Shoes.OrderByDescending(s => s.Denumire);
                        break;
                }

            }
        }
    }
}
