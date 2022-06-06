using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaApp_Backend.Models
{
    public class OrderDetail
    {
        [Key, Column(Order = 0)]
        public int OrderID { get; set; }
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        public int OrderQuantity { get; set; }
        public int OrderTotalProduct { get; set; }

    }
}
