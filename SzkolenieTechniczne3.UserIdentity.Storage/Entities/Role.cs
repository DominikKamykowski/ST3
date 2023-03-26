using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.UserIdentity.Storage.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    [Table("Users", Schema = "Identity")]


    class Role
    {
        [MinLength(2)]
        [MaxLength(64)]
        [Required]
        public string Name { get; set; } = null!;

        [MinLength(2)]
        [MaxLength(64)]
        [Required]
        public string Description { get; set; } = null!;

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
