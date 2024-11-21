using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Address
{
    public class GetAddressByIdRequest(int id) : IRequest<GetAddressByIdResponse>
    {
        public int Id { get; set; } = id;
    }
}
