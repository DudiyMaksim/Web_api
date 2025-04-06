using AutoMapper;
using spr311_web_api.DAL.Entities.Identity;
using Web_api.BLL.Dtos.Account;
using Web_api.BLL.Dtos.Category;
using Web_api.DAL.Entities;

namespace Web_api.MapperProfiles
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            //RegisterDto -> AppUser
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
