using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers
{
    public class CredentialsValidator
    {
        public bool ValidatePassword(string password)
        {
            return password.Length >= 8 && password.Any(char.IsDigit) && password.Any(char.IsUpper);
        }
        public bool ConfirmPassword(string password, string passwordConfirmation)
        {
            return password == passwordConfirmation;
        }

        public bool ValidatePhoneNumber(string phoneNumber)
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
        public bool AgeValidator(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (age < 18)
            {
                return false;
            }
            return true;
        }
    }

}
