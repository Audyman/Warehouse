using Autofac;
using Warehouse.DataProvider.Database;
using Warehouse.DataProvider.Repositories.Products;

namespace Warehouse.DataProvider
{
    public class DataProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new DatabaseFactory()).As<IDatabaseFactory>().InstancePerRequest();
            builder.RegisterType<CommitProvider>().As<ICommitProvider>().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerRequest();

            base.Load(builder);
        }
    }
}