using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTrackPro.Domain.Entities
{
    public class CustomerDemographics
    {
        public string CustomerTypeId { get; set; }

        public string CustomerDesc { get; set; }

        public virtual ICollection<Customers> Customers { get; set; } = new List<Customers>();
    }
}
