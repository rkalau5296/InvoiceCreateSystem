﻿using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetAddressByIdQuery : QueryBase<Address>
    {
        public int Id { get; set; }
        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
        public override async Task<Address> Execute(InvoiceContext context)
        {
            return await context.Addresses.FirstOrDefaultAsync(a => a.Id == Id);
        }
    }
}
