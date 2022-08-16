using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        ICustomerRepository Customers { get; }
    }
}
