using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities;

namespace Test.Application.Abstractions
{
    public interface ICustomerDBContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        public DbSet<Customer> Customers { get; set; }
    }
}
