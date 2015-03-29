﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Model.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public int ProductGroupId { get; set; }

        [ForeignKey("ProductGroupId")]
        public virtual ProductGroup ProductGroup { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}