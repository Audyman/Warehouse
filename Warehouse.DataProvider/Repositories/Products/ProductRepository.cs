using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Warehouse.DataProvider.Database;
using Warehouse.Model.Entities;
using Warehouse.Model.Enums;

namespace Warehouse.DataProvider.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product, WarehouseContext>, IProductRepository
    {
        public ProductRepository() { }

        public ProductRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

        public int Count(Expression<Func<Product, bool>> @where)
        {
            return DbSet.Where(where).Count();
        }

        public IEnumerable<Product> GetByType(ProductType type)
        {
            return DbSet.Where(e => e.Type == type).ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return DbSet.Where(e => !e.IsDeleted).ToList();
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return DbSet.Where(e => e.Name.Contains(name)).ToList();
        }
    }

    public interface IProductRepository : IGenericRepository<Product>
    {
        int Count(Expression<Func<Product, bool>> where);
        IEnumerable<Product> GetByType(ProductType type);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetByName(string name);
    }
}