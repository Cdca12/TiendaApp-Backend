using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaApp_Backend.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }

        public int ClientID { get; set; }

    }
}
