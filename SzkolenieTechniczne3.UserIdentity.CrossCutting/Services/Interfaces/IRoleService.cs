using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.dtos;

namespace SzkolenieTechniczne3.UserIdentity.CrossCutting.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> Read();
        Task<RoleDto> ReadById(Guid id);
        Task<RoleDto> Create(RoleDto dto);
        Task<RoleDto> Update(RoleDto dto);
        Task Delete(Guid id);
        Task AssignRolesToUser(Guid userId, Guid[] roleIds);


    }
}
