using Autofac;
using AutoMapper;
using Warehouse.Logic.Services.Products;

namespace Warehouse.Logic
{
    public class LogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
            builder.RegisterType<ProductGroupService>().As<IProductGroupService>().InstancePerRequest();
            builder.Register<IMappingEngine>(x => Mapper.Engine).SingleInstance();

            base.Load(builder);
        }
    }
}