using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Abstractions;

namespace Test.Application.Features.Commands
{
    public class DeleteCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteCustomerRequestHandler : IRequestHandler<DeleteCustomerRequest, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteCustomerRequestHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<int> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
            {
                var customer =await _unitOfWork.Customers.GetByIdAsync(request.Id);
                if (customer == null)
                {
                    return default;
                }

                _unitOfWork.Customers.Remove(customer);
                await _unitOfWork.SaveChangesAsync();

                return customer.Id;

            }
        }
    }
}
