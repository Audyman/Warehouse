namespace Warehouse.Model.Entities
{
    public class BaseProduct : BaseEntity
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}