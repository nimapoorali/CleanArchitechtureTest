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
    public class GetAllCustomersRequest : IRequest<IEnumerable<Customer>>
    {
        public class GetAllCustomersRequestHandler : IRequestHandler<GetAllCustomersRequest, IEnumerable<Customer>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetAllCustomersRequestHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Customer>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Customers.GetAllAsync();
            }

        }
    }
}
