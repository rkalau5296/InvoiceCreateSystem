using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.ApplicationServices.Mappings
{
    public class InvoicePositionProfile : Profile
    {
        public InvoicePositionProfile()
        {
            CreateMap<DataAccess.Entities.InvoicePosition, InvoicePosition>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Lp, y => y.MapFrom(z => z.Lp))
                .ForMember(x => x.Value, y => y.MapFrom(z => z.Value))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity));
        }
    }
}
