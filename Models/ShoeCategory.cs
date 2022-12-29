namespace Dan_Daniela_Proiect_Web.Models
{
    public class ShoeCategory
    {
        public int ID { get; set; }
        public int ShoeID { get; set; }
        public Shoe Shoe { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
