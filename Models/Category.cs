namespace Dan_Daniela_Proiect_Web.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ShoeCategory>? ShoeCategories { get; set; }
    }
}
