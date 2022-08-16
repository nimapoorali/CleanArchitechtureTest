using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Abstractions;

namespace Test.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerDBContext _context;
        public ICustomerRepository Customers { get; private set; }

        public UnitOfWork(CustomerDBContext context)
        {
            _context = context;

            Customers = new CustomerRepository(_context);
        }
        public async void Dispose()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
