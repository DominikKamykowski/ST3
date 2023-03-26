using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.UserIdentity.CrossCutting.dtos
{
    public record UserDto
    {
        public Guid Id { set; get; }

        [MaxLength(128)]
        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;

        [MinLength(2)]
        [MaxLength(64)]
        [Required]
        public string FirstName { get; set; } = null!;

        [MinLength(2)]
        [MaxLength(64)]
        [Required]
        public string LastName { get; set; } = null!;

        [MinLength(9)]
        [MaxLength(9)]
        public string PhoneNumber { get; set; }

    }
}
