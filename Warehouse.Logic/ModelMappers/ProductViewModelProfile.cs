using AutoMapper;
using Warehouse.Model.Entities;
using Warehouse.ViewModel.Products;

namespace Warehouse.Logic.ModelMappers
{
    internal sealed class ProductViewModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(x => x.Type, opt => opt.MapFrom(s => s.ProductType))
                .ForMember(x => x.TotalNumber, opt => opt.MapFrom(s => s.TotalNumber))
                .ForMember(x => x.SaleNumber, opt => opt.MapFrom(s => s.SaleNumber))
                .ForMember(x => x.Price, opt => opt.MapFrom(s => s.Price));
        }
    }
}