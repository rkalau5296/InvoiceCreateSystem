using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InvoiceCreateSystem.DataAccess
{
    public class InvoiceContextFactory : IDesignTimeDbContextFactory<InvoiceContext>
    {
        public InvoiceContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<InvoiceContext>();
            optionBuilder.UseSqlServer("Data Source=LAPTOP-ITT5H8GO\\SQLEXPRESS;Initial Catalog=InvoiceCreateSystem;Integrated Security=True;Trust Server Certificate=True");
            return new InvoiceContext(optionBuilder.Options);
        }
    }
}
