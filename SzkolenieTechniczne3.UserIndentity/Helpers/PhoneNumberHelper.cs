using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.UserIndentity.Helpers
{
    public static class PhoneNumberHelper
    {
        public static string SanitizePhoneNumber(string? phoneNumber)
        {
            var number = phoneNumber?.Replace(" ", string.Empty).Replace("-", string.Empty).Replace("+", string.Empty);
            if (string.IsNullOrEmpty(number) || !number.All(char.IsDigit))
            {
                return string.Empty;
            }
            return number.Insert(0, "+");
        }
    }
}
