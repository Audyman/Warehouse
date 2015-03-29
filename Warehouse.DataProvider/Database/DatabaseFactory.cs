using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Warehouse.DataProvider.Database
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private static readonly object LockObj = new object();
        private readonly Dictionary<Type, DbContext> _dataContexts = new Dictionary<Type, DbContext>();
        private int _disposeCount = 0;

        public DatabaseFactory()
        {
        }

        public IDatabaseContext Get<TContext>() where TContext : DbContext
        {
            {
                lock (LockObj)
                {
                    if (!_dataContexts.ContainsKey(typeof(TContext)))
                    {
                        DbContext dataContext;
                        if (typeof(TContext) == typeof(WarehouseContext))
                            dataContext = new WarehouseContext();
                        else
                            throw new NotSupportedException(typeof(TContext).ToString());

                        _dataContexts.Add(typeof(TContext), dataContext);
                    }
                }
            }
            return (IDatabaseContext)_dataContexts[typeof(TContext)];
        }

        protected override void DisposeCore()
        {
            _disposeCount++;

            if (_dataContexts != null)
            {
                foreach (var dataContext in _dataContexts)
                    dataContext.Value.Dispose();
                _dataContexts.Clear();
            }
        }
    }

    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}