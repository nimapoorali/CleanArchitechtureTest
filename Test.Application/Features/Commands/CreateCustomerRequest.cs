using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Abstractions;
using Test.Entities;

namespace Test.Application.Features.Commands
{
    public class CreateCustomerRequest : IRequest<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

        public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateCustomerRequestHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<int> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
            {
                var customer = new Customer()
                {
                    BankAccountNumber = request.BankAccountNumber,
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    PhoneNumber = request.PhoneNumber
                };

                _unitOfWork.Customers.Add(customer);
                await _unitOfWork.SaveChangesAsync();

                return customer.Id;
            }
        }
    }
}
