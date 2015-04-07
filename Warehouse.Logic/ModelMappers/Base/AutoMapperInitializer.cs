using AutoMapper;

namespace Warehouse.Logic.ModelMappers.Base
{
    public class AutoMapperInitializer
    {
        public static void InitAutoMapper()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductViewModelProfile>();
                x.AddProfile<SignUpViewModelProfile>();
            });
        }
    }
}