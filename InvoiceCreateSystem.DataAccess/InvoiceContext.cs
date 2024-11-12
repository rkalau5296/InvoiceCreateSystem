using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess
{
    public class InvoiceContext(DbContextOptions<InvoiceContext> opt) : DbContext(opt)
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<InvoicePosition> InvoicePositions { get; set; }
        public DbSet<MethodOfPayment> MethodOfPayments { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - one-to-many relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.Products)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Invoices)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Clients)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.MethodOfPayments)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Client - one-to-many relationships with Invoice
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Invoices)
                .WithOne(i => i.Client)
                .HasForeignKey(i => i.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
            
            // MethodOfPayment - one-to-many relationships with Invoice
            modelBuilder.Entity<MethodOfPayment>()
                .HasMany(m => m.Invoices)
                .WithOne(i => i.MethodOfPayment)
                .HasForeignKey(i => i.MethodOfPaymentId)
                .OnDelete(DeleteBehavior.NoAction);

            // InvoicePosition - one-to-many relationship with Invoice
            modelBuilder.Entity<InvoicePosition>()
                .HasOne(ip => ip.Invoice)
                .WithMany(i => i.InvoicePositions)
                .HasForeignKey(ip => ip.InvoiceId)
                .OnDelete(DeleteBehavior.NoAction);

            // InvoicePosition - one-to-many relationship with Product
            modelBuilder.Entity<InvoicePosition>()
                .HasOne(ip => ip.Product)
                .WithMany(p => p.InvoicePositions)
                .HasForeignKey(ip => ip.ProductId)
                .OnDelete(DeleteBehavior.NoAction); // Zmień na NoAction, aby uniknąć cykli

            // Configurations for other entities
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<MethodOfPayment>().ToTable("MethodsOfPayment");
            modelBuilder.Entity<InvoicePosition>().ToTable("InvoicePositions");
        }



    }
}