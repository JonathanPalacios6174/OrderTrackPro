﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTrackPro.Domain.Entities
{
    public class Products
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public virtual Categories Category { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        public virtual Suppliers Supplier { get; set; }
    }
}
