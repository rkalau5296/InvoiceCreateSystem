using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InvoiceCreateSystem.DataAccess;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InvoiceContext>
{
    public InvoiceContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<InvoiceContext>();
        optionsBuilder.UseSqlite("Data Source=invoices.db");

        return new InvoiceContext(optionsBuilder.Options);
    }
}