using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTrackPro.Domain.Entities
{
    public class Shippers
    {
        public int ShipperId { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
