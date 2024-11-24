using AppParkingSys_Back.Core.Entities;
using AppParkingSys_Back.Web.Models;
using AutoMapper;

namespace AppParkingSys_Back.Web.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Entities to Models
            CreateMap<User, UserModel>();
            CreateMap<User, UserSaveModel>();
            //Models to Entities
            CreateMap<UserModel, User>();
            CreateMap<UserSaveModel, User>();
        }
    }
}
