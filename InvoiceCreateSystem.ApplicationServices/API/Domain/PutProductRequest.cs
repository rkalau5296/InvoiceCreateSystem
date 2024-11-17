using InvoiceCreateSystem.DataAccess.Entities;
//using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain
{
    public class PutProductRequest : IRequest<PutProductResponse>
    {
        public Product Product { get; }
        public int Id { get; set; }
        public PutProductRequest(int id, Product product)
        {
            this.Id = id;
            this.Product = product;
        }
    }
}
