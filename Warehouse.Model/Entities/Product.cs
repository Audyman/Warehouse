namespace Warehouse.Model.Entities
{
    public class Product : BaseEntity
    {
        public int TotalNumber { get; set; }
        public int SaleNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int Price { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}