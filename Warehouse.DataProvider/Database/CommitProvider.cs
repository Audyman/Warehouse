using System;

namespace Warehouse.DataProvider.Database
{
    public class CommitProvider : ICommitProvider
    {
        private readonly IDatabaseFactory _dbFactory;

        public CommitProvider(IDatabaseFactory dbFactory)
        {
            if (dbFactory != null)
                _dbFactory = dbFactory;
        }

        public void Commit()
        {
            var warehouseContext = ((IWarehouseContext)_dbFactory.Get<WarehouseContext>());
            warehouseContext.SaveChanges();
        }

        public void AddToExecuteOnCommit(Action action)
        {
            throw new NotImplementedException();
        }

        private bool _disposed;
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbFactory.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}