using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTrackPro.Domain.Entities
{
    public class Customers
    {
        public string CustomerId { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();

        public virtual ICollection<CustomerDemographics> CustomerTypes { get; set; } = new List<CustomerDemographics>();
    }
}
