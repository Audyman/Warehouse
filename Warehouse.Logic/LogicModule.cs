using Autofac;
using Warehouse.Logic.Services.Products;

namespace Warehouse.Logic
{
    public class LogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();

            base.Load(builder);
        }
    }
}