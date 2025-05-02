using System.ComponentModel;

namespace Web.Models
{
    public class OrderLineViewModel
    {
        
        public int OrderId { get; set; }

        [DisplayName("Product")]
        public string Product { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("UnitPrice")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Total")]
        public decimal Total => Quantity * UnitPrice;   
        
    }
}
