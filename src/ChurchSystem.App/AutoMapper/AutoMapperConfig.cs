using AutoMapper;
using ChurchSystem.App.ViewsModels;
using ChurchSystem.Business.Models;

namespace ChurchSystem.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Member, MemberViewModel>().ReverseMap();
            CreateMap<Donation, DonationViewModel>().ReverseMap();
            CreateMap<Group, GroupViewModel>().ReverseMap();
            CreateMap<Role, RoleViewModel>().ReverseMap();
        }
    }
}
