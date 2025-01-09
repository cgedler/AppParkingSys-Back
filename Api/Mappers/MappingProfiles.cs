using Api.Models;
using AutoMapper;
using Core.Entities;

namespace Api.Mappers
{
    /// <summary>
    ///  Class <c>MappingProfiles</c> to map from one object to another
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Entities to Models
            CreateMap<User, UserModel>();
            CreateMap<User, UserSaveModel>();
            CreateMap<Ticket, TicketModel>();
            CreateMap<Ticket, TicketSaveModel>();
            CreateMap<Price, PriceModel>();
            CreateMap<Price, PriceSaveModel>();
            CreateMap<Payment, PaymentModel>();
            CreateMap<Payment, PaymentSaveModel>();
            //Models to Entities
            CreateMap<UserModel, User>();
            CreateMap<UserSaveModel, User>();
            CreateMap<TicketModel, Ticket>();
            CreateMap<TicketSaveModel, Ticket>();
            CreateMap<PriceModel, Price>();
            CreateMap<PriceSaveModel, Price>();
            CreateMap<PaymentModel, Payment>();
            CreateMap<PaymentSaveModel, Payment>();
        }
    }
}
