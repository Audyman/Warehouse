using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Warehouse.DataProvider.Repositories
{
    public interface IGenericRepository<TEntity> : IGenericRepository
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> GetQueryable(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        EntityState State(TEntity entity);
    }

    public interface IGenericRepository
    {
        void Delete(int id);
    }
}