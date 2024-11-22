using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
