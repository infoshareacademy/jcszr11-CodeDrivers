using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers
{
    public class UserValidationHelper
    {
        public bool IsValidEmail(string email)
        {
            return email.Length >= 6 && email.Contains("@");
        }

        public bool IsValidPassword(string password)
        {
            return password.Length >= 8 && password.Any(char.IsDigit) && password.Any(char.IsUpper);
        }
        public bool IsConfirmedPassword(string password, string passwordConfirmation)
        {
            return password == passwordConfirmation;
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            PhoneNumbers.PhoneNumberUtil phoneUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();

            try
            {
                var parsedPhoneNumber = phoneUtil.ParseAndKeepRawInput(phoneNumber, "PL");

                if (phoneUtil.IsValidNumber(parsedPhoneNumber))
                {
                    PhoneNumbers.PhoneNumberType numberType = phoneUtil.GetNumberType(parsedPhoneNumber);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool IsMoreThan18(DateTime dateOfBirth) => (DateTime.Today - dateOfBirth).TotalDays / 365 >= 18;
    }

}
