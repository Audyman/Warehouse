using System.Collections.Generic;

namespace Warehouse.Model.Entities
{
    public class ProductGroup : BaseEntity
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
}