using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dan_Daniela_Proiect_Web.Models
{
    public class Shoe
    {
        public int ID { get; set; }
        public string Denumire { get; set; }

        public int? BrandID { get; set; }
        public Brand? Brand{ get; set; } //navigation property

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]

        public decimal Pret { get; set; }

        public string Descriere { get; set; }

        public ICollection<ShoeCategory>? ShoeCategories { get; set;  }

    }
}
