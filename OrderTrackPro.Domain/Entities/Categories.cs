using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTrackPro.Domain.Entities
{
    public class Categories
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public virtual ICollection<Products> Products { get; set; } = new List<Products>();

    }
}
