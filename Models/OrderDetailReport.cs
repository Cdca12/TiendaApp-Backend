namespace TiendaApp_Backend.Models
{
    public class OrderDetailReport
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int OrderQuantity { get; set; }
        public decimal OrderTotalProduct { get; set; }

    }
}
