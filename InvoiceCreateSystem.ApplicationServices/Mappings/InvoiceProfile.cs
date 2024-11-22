using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;

namespace InvoiceCreateSystem.ApplicationServices.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<DataAccess.Entities.Invoice, Invoice>()
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Value, y => y.MapFrom(z => z.Value))
                .ForMember(x => x.MethodOfPaymentId, y => y.MapFrom(z => z.MethodOfPaymentId))
                .ForMember(x => x.PaymentDate, y => y.MapFrom(z => z.PaymentDate))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.Comments, y => y.MapFrom(z => z.Comments))
                .ForMember(x => x.ClientId, y => y.MapFrom(z => z.ClientId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));
        }
    }
}
