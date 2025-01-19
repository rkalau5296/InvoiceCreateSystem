﻿using InvoiceCreateSystem.DataAccess.CQRS.Queries;

namespace InvoiceCreateSystem.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly InvoiceContext invoiceContext;

        public QueryExecutor(InvoiceContext invoiceContext)
        {
            this.invoiceContext = invoiceContext;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.invoiceContext);
        }
    }
}
