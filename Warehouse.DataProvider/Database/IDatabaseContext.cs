using System.Data.Entity.Infrastructure;

namespace Warehouse.DataProvider.Database
{
    public interface IDatabaseContext
    {
        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}