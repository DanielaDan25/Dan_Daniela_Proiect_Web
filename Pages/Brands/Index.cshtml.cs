using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dan_Daniela_Proiect_Web.Data;
using Dan_Daniela_Proiect_Web.Models;
using System.Security.Policy;
using Dan_Daniela_Proiect_Web.ViewModels;

namespace Dan_Daniela_Proiect_Web.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext _context;

        public IndexModel(Dan_Daniela_Proiect_Web.Data.Dan_Daniela_Proiect_WebContext context)
        {
            _context = context;
        }

        public IList<Brand> Brand { get;set; } = default!;

        public BrandIndexData BrandData { get; set; }
        public int BrandID { get; set; }
        public int ShoeID { get; set; }
        public async Task OnGetAsync(int? id, int? shoeID)
        {
            BrandData = new BrandIndexData();
            BrandData.Brands = await _context.Brand
            .Include(i => i.Shoes)
            .OrderBy(i => i.BrandName)
            .ToListAsync();
            if (id != null)
            {
                BrandID = id.Value;
                Brand brand = BrandData.Brands
                .Where(i => i.ID == id.Value).Single();
                BrandData.Shoes = brand.Shoes;
            }
        }
    }
}
