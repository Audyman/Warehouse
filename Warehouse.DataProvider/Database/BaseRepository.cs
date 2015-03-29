using System;
using System.Data.Entity;

namespace Warehouse.DataProvider.Database
{
    public abstract class BaseRepository<TContext>
        where TContext : DbContext
    {
        protected TContext DataContext { get; private set; }

        protected BaseRepository(IDatabaseFactory dbFactory)
        {
            DataContext = dbFactory.Get<TContext>() as TContext;
            if (DataContext == null)
                throw new NullReferenceException();
        }
    }
}