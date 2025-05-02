using System.ComponentModel;

namespace Web.Models
{
    public class OrderViewModel

    {
        public int OrderId { get; set; }

        [DisplayName("Customer")]
        public string Customer { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Shipping address")]
        public string ShippingAddress { get; set; }

        [DisplayName("Employee")]
        public string Employee { get; set; }

    }
}
