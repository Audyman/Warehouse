namespace Warehouse.DataProvider.Database
{
    public interface IWarehouseContext : IDatabaseContext
    {
        void CloseContext();
    }
}