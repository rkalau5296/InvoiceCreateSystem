using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Client
{
    public class GetClientByIdRequest(int id) : IRequest<GetClientByIdResponse>
    {
        public int Id { get; set; } = id;
    }
}
