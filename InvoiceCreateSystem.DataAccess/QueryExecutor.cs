using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
