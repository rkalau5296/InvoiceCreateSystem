using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly InvoiceContext context;

        public CommandExecutor(InvoiceContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(context);
        }
    }
}
