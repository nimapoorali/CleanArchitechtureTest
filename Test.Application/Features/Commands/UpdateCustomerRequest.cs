using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Abstractions;

namespace Test.Application.Features.Commands
{
    public class UpdateCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

        public class UpdateCustomerRequestHandler : IRequestHandler<UpdateCustomerRequest, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateCustomerRequestHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<int> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
            {
                var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);
                if (customer == null)
                {
                    return default;
                }

                customer.BankAccountNumber = request.BankAccountNumber;
                customer.DateOfBirth = request.DateOfBirth;
                customer.Email = request.Email;
                customer.Firstname = request.Firstname;
                customer.Lastname = request.Lastname;
                customer.PhoneNumber = request.PhoneNumber;

                await _unitOfWork.SaveChangesAsync();

                return customer.Id;
            }
        }
    }
}
