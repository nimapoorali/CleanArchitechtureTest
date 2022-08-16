using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Abstractions;
using Test.Entities;

namespace Test.Infrastructure.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly CustomerDBContext _context;

        public CustomerRepository(CustomerDBContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Set<Customer>().Add(entity);
        }

        public async Task<IEnumerable<Customer>> FindAsync(Expression<Func<Customer, bool>> expression)
        {
            return await _context.Set<Customer>().Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Set<Customer>().ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Set<Customer>().FindAsync(id);
        }

        public void Remove(Customer entity)
        {
            _context.Set<Customer>().Remove(entity);
        }

        public void Update(Customer entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
