using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands
{
    public abstract class CommandBase<TParametr, TResult>
    {
        public TParametr Parametr { get; set; }

        public abstract Task<TResult> Execute(InvoiceContext context);
    }
}
