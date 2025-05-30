﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTrackPro.Domain.Entities
{
    public class Region
    {
        public int RegionId { get; set; }

        public string RegionDescription { get; set; }

        public virtual ICollection<Territories> Territories { get; set; } = new List<Territories>();
    }
}
