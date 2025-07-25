﻿using InvoiceCreateSystem.DataAccess.Entities;

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
