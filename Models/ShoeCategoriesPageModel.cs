using Microsoft.AspNetCore.Mvc.RazorPages;
using Dan_Daniela_Proiect_Web.Models;
using Dan_Daniela_Proiect_Web.Data;

namespace Dan_Daniela_Proiect_Web.Models
{ 
    public class ShoeCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Dan_Daniela_Proiect_WebContext context, Shoe shoe)
        {
            var allCategories = context.Category;
            var shoeCategories = new HashSet<int>(
            shoe.ShoeCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = shoeCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateShoeCategories(Dan_Daniela_Proiect_WebContext context,
        string[] selectedCategories, Shoe shoeToUpdate)
        {
            if (selectedCategories == null)
            {
                shoeToUpdate.ShoeCategories = new List<ShoeCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var shoeCategories = new HashSet<int>
            (shoeToUpdate.ShoeCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!shoeCategories.Contains(cat.ID))
                    {
                        shoeToUpdate.ShoeCategories.Add(
                        new ShoeCategory
                        {
                            ShoeID = shoeToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (shoeCategories.Contains(cat.ID))
                    {
                        ShoeCategory courseToRemove
                        = shoeToUpdate
                        .ShoeCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
    }

