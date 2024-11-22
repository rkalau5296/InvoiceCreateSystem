using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;

namespace InvoiceCreateSystem.ApplicationServices.Mappings
{
    public class AddressProfile : Profile
    {
        public AddressProfile() 
        {
            CreateMap<DataAccess.Entities.Address, Address>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.PostalCode, y => y.MapFrom(z => z.PostalCode))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Street))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number));
        }
    }
}
