using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Entities;

namespace Test.Application.Abstractions
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<IEnumerable<Customer>> FindAsync(Expression<Func<Customer, bool>> expression);
        void Add(Customer entity);
        void Update(Customer entity);
        void Remove(Customer entity);

    }
}
