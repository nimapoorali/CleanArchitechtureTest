using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Abstractions;
using Test.Entities;

namespace Test.Application.Features.Queries
{
    public class GetCustomerByIdRequest : IRequest<Customer>
    {
        public int Id { get; set; }

        public class GetCustomerByIdRequestHandler : IRequestHandler<GetCustomerByIdRequest, Customer>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetCustomerByIdRequestHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Customer> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Customers.GetByIdAsync(request.Id);
            }
        }
    }
}
