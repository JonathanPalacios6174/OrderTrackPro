using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTrackPro.Domain.Entities
{
    public class Shipper
    {
        public int ShipperId { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
