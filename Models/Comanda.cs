using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Dan_Daniela_Proiect_Web.Models
{
    public class Comanda
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? ShoeID { get; set; }
        public Shoe? Shoe { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpediereData { get; set; }
    }
}
