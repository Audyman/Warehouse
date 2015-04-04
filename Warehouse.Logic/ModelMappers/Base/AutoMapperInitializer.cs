using AutoMapper;

namespace Warehouse.Logic.ModelMappers.Base
{
    public class AutoMapperInitializer
    {
        public static void InitAutoMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductViewModelProfile>());
        }
    }
}