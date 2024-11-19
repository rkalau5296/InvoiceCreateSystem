using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;

namespace InvoiceCreateSystem.ApplicationServices.Mappings
{
    public class ClientsProfile : Profile
    {
        public ClientsProfile()
        {
            CreateMap<DataAccess.Entities.Client, Client>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.AddressId, y => y.MapFrom(z => z.AddressId))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));
        }            
    }
}
