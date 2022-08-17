using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Features.Commands.Validators
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(c => c.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is not valid!")
                .Must(ValidationHelpers.ValidatePhoneNumber).WithMessage("{PropertyName} is not valid!");

            RuleFor(c => (c.Email))
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} can not be empty!");

            RuleFor(c => (c.Email))
                .Cascade(CascadeMode.Stop)
                .EmailAddress().WithMessage("{PropertyName} has invalid value!");
        }
    }
}
