using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Features.Commands.Validators
{
    public static class ValidationHelpers
    {
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();

            try
            {
                var parsedPhoneNumber = phoneNumberUtil.Parse(phoneNumber, null);
                return true;
            }
            catch (NumberParseException)
            {
                return false;
            }

        }
    }
}
