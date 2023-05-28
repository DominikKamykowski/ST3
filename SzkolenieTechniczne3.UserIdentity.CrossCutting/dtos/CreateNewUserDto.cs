using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.UserIdentity.CrossCutting.dtos
{
    public class CreateNewUserDto :UpdateUserDto
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(PhoneNumber))
            {
                yield return new ValidationResult("Phone number or Email is required!",
                    new[] { nameof(Email), nameof(PhoneNumber) });
            }
            if(!string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
            {
                yield return new ValidationResult("Password is required", new[] { nameof(Password) });
            }
        }
    }
}
