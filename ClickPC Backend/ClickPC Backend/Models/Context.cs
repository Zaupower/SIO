using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickPC_Backend.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<LineInvoice> LineInvoice { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().ToTable("Account");
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Supplier>().ToTable("Supplier");
            builder.Entity<Transaction>().ToTable("Transaction");
            builder.Entity<Product>().ToTable("Product");
            builder.Entity<Invoice>().ToTable("Invoice");
            builder.Entity<LineInvoice>().ToTable("LineInvoice");

            builder.Entity<Account>().HasKey(a => a.Id);
            builder.Entity<Customer>().HasKey(c => c.Id);
            builder.Entity<Supplier>().HasKey(s => s.Id);
            builder.Entity<Transaction>().HasKey(t => t.Id);
            builder.Entity<Product>().HasKey(t => t.Id);
            builder.Entity<Invoice>().HasKey(t => t.Id);
            builder.Entity<LineInvoice>().HasKey(t => t.Id);

            builder.Entity<LineInvoice>().Property(c => c.Id).ValueGeneratedOnAdd();
        }
    }
}

