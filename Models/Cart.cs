namespace TiendaApp_Backend.Models
{
    public class Cart
    {
        public int[] ProductsID { get; set; }
        public int[] Quantity { get; set; }
        public int ClientID { get; set; }

    }
}
