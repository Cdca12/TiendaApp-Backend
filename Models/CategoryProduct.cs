using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaApp_Backend.Models
{
    public class CategoryProduct
    {
        [Key, Column(Order = 0)]
        public int CategoryID { get; set; }
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }

    }
}
