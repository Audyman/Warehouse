using System;
using System.Data.Entity;

namespace Warehouse.DataProvider.Database
{
    public interface IDatabaseFactory : IDisposable
    {
        IDatabaseContext Get<TContext>() where TContext : DbContext;
    }
}