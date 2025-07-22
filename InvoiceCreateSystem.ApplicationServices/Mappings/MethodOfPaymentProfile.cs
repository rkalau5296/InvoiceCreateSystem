using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;

namespace InvoiceCreateSystem.ApplicationServices.Mappings
{
    public class MethodOfPaymentProfile : Profile
    {
        public MethodOfPaymentProfile() 
        {
            CreateMap<DataAccess.Entities.MethodOfPayment, MethodOfPayment>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));               

        }
    }
}
