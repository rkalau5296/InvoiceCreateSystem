using InvoiceCreateSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands
{
    public class PostAddressCommand : CommandBase<Address, Address>
    {
        public override async Task<Address> Execute(InvoiceContext context)
        {
            await context.Addresses.AddAsync(this.Parametr);
            await context.SaveChangesAsync();
            return this.Parametr;
        }
    }
}
