using System.Collections.Generic;

namespace Warehouse.Model.Entities
{
    public class ProductGroup : BaseProduct
    {
        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
}