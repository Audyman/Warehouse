using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Warehouse.DataProvider.Database;

namespace Warehouse.DataProvider.Repositories
{
    public abstract class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        internal IDatabaseFactory DbFactory;
        internal TContext Context;
        internal DbSet<TEntity> DbSet;

        protected GenericRepository(IDatabaseFactory dbFactory)
        {
            DbFactory = dbFactory;
            Context = (TContext)dbFactory.Get<TContext>();
            DbSet = Context.Set<TEntity>();
        }

        protected GenericRepository()
        {
        }

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetQueryable(includeProperties);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public IQueryable<TEntity> GetQueryable(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (includeProperties == null) throw new ArgumentNullException("includeProperties");

            IQueryable<TEntity> query = DbSet;

            foreach (var includeProperty in includeProperties)
            {
                if (includeProperty == null) throw new ArgumentNullException("includeProperties", "Parameter <includeProperties> contain element that null reference.");
                var methodExpression = (includeProperty.Body as MemberExpression);
                if (methodExpression == null) throw new ArgumentException("Parameter <includeProperties> should contain only assign to property.");

                query = query.Include(GetPath(includeProperty));
            }

            return query;
        }

        private static string GetPath(Expression exp)
        {
            switch (exp.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var name = GetPath(((MemberExpression)exp).Expression) ?? String.Empty;
                    if (name.Length > 0) name += ".";
                    return name + ((MemberExpression)exp).Member.Name;
                case ExpressionType.Convert:
                case ExpressionType.Quote:
                    return GetPath(((UnaryExpression)exp).Operand);
                case ExpressionType.Lambda:
                    return GetPath(((LambdaExpression)exp).Body);
                default:
                    return null;
            }
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(int id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (DbFactory.Get<TContext>().Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (DbFactory.Get<TContext>().Entry(entityToUpdate).State == EntityState.Detached)
            {
                DbSet.Attach(entityToUpdate);
                DbFactory.Get<TContext>().Entry(entityToUpdate).State = EntityState.Modified;
            }
        }

        public EntityState State(TEntity entity)
        {
            return DbFactory.Get<TContext>().Entry(entity).State;
        }

        protected virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return DbSet.SqlQuery(query, parameters).ToList();
        }
    }
}