using Api.Models;
using AutoMapper;
using Core.Entities;

namespace Api.Mappers
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
