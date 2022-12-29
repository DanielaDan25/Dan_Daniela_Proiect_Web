namespace Dan_Daniela_Proiect_Web.Models
{
    public class ShoeData
    {
        public IEnumerable<Shoe> Shoes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ShoeCategory> ShoeCategories { get; set; }
    }
}
