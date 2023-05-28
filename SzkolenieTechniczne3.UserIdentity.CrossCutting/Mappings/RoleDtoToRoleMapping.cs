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
    public class RoleDtoToRoleMapping : Mapping<RoleDto,Role>
    {
        public override Expression<Func<RoleDto,Role>>GetMapping()
        {
            return d => new Role
            {
                Id = d.Id,
                Description = d.Description,
                Name = d.Name
            };
        }
    }
}
