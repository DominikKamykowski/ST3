using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.UserIdentity.CrossCutting.dtos
{
    public record RoleDto
    {
        public Guid Id { set; get; }

        [MinLength(2)]
        [MaxLength(64)]
        [Required]
        public string Name { get; set; } = null!;

        [MaxLength(64)]
        public string Description { get; set; } = null!;
        public Guid[]? UserIds { get; set; }
    }
}
