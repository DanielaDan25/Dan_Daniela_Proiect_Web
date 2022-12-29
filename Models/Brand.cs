namespace Dan_Daniela_Proiect_Web.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public ICollection<Shoe>? Shoes{ get; set; } //navigation property
    }
}
