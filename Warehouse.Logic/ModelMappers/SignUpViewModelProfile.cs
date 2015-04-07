using AutoMapper;
using Warehouse.Model.Entities;
using Warehouse.ViewModel.Users;

namespace Warehouse.Logic.ModelMappers
{
    public class SignUpViewModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<SignUpViewModel, UserProfile>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(x => x.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(x => x.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(x => x.UserId, opt => opt.Ignore());
        }
    }
}