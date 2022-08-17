using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Abstractions;
using Test.Entities;

namespace Test.Infrastructure.Persistence
{
    public class CustomerDBContext : DbContext, ICustomerDBContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)
        {

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(true, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add-migration initializeDatabase -context CustomerDBContext -outputdir Persistence\Migrations -startupproject Test.Api
            //update-database -context CustomerDBContext -startupproject Test.Api
            modelBuilder
                .Entity<Customer>()
                .Property(c => c.PhoneNumber)
                .HasColumnType("varchar");

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
