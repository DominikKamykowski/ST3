using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.Common.Storage.Entities;

namespace SzkolenieTechniczne3.UserIdentity.Storage.Entities
{
    [Table("Users", Schema = "Identity")]
    [Index(nameof(Email), IsUnique =false)]

    public class User :BaseEntity
    {
        [MinLength(2)]
        [MaxLength(128)]
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
        [MaxLength(256)]
        [Required]
        public string Password { get; set; } = null!;

        [MinLength(9)]
        [MaxLength(64)]
        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<Role> Roles { get; set; } = new HashSet<Role>();


    }
}
