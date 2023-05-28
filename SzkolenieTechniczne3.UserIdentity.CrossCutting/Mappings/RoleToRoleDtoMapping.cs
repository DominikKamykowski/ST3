using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.Common.CrossCutting.Mappings;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.dtos;
using SzkolenieTechniczne3.UserIdentity.Storage.Entities;

namespace SzkolenieTechniczne3.UserIdentity.CrossCutting.Mappings
{
    public class RoleToRoleDtoMapping: Mapping<Role, RoleDto>
    {
        public override Expression<Func<Role,RoleDto>> GetMapping()
        {
            return e => new RoleDto
            {
                Id = e.Id,
                Description = e.Description,
                Name = e.Name,
                UserIds = e.Users.Select(u => u.Id).ToArray()
            };
        }
    }
}
