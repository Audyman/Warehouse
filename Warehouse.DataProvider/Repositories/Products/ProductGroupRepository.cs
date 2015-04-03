using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Warehouse.DataProvider.Database;
using Warehouse.Model.Entities;

namespace Warehouse.DataProvider.Repositories.Products
{
    public class ProductGroupRepository : GenericRepository<ProductGroup, WarehouseContext>, IProductGroupRepository
    {
        public ProductGroupRepository() { }

        public ProductGroupRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

        public int Count(Expression<Func<ProductGroup, bool>> @where)
        {
            return DbSet.Where(where).Count();
        }

        public IEnumerable<ProductGroup> GetAllActiveGroups()
        {
            return DbSet.Where(e => !e.IsDeleted);
        }

        public IEnumerable<ProductGroup> GetAllDeletedGroups()
        {
            return DbSet.Where(e => !e.IsDeleted);
        }

        public IEnumerable<ProductGroup> GetByName(string name)
        {
            return DbSet.Where(e => e.Name.Contains(name) && !e.IsDeleted).ToList();
        }
    }

    public interface IProductGroupRepository : IGenericRepository<ProductGroup>
    {
        int Count(Expression<Func<ProductGroup, bool>> where);
        IEnumerable<ProductGroup> GetAllActiveGroups();
        IEnumerable<ProductGroup> GetAllDeletedGroups();
        IEnumerable<ProductGroup> GetByName(string name);
    }
}