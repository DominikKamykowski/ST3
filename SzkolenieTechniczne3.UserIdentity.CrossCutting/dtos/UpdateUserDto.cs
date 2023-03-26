using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.UserIdentity.CrossCutting.dtos
{
    public class UpdateUserDto :IValidatableObject
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; }
        public string Password { get; set; }


        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(PhoneNumber))
            {
                yield return new ValidationResult("Phone number or Email is required!",
                    new[] { nameof(Email), nameof(PhoneNumber) });
            }
        }
    }
}
