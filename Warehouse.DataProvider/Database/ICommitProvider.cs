using System;

namespace Warehouse.DataProvider.Database
{
    public interface ICommitProvider : IDisposable
    {
        void Commit();
        void AddToExecuteOnCommit(Action action);
    }
}