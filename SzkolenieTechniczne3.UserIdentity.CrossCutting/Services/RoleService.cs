using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.dtos;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.Mappings;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.Services.Interfaces;
using SzkolenieTechniczne3.UserIdentity.Storage;
using SzkolenieTechniczne3.UserIdentity.Storage.Entities;

namespace SzkolenieTechniczne3.UserIdentity.CrossCutting.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserIdentityDbContext _dbContext;
        private readonly RoleToRoleDtoMapping _entityToDtoMapping;
        private readonly RoleDtoToRoleMapping _dtoToEntityMapping;

        public RoleService(UserIdentityDbContext dbContext, RoleToRoleDtoMapping entityToDtoMapping,
            RoleDtoToRoleMapping dtoToEntityMapping)
        {
            _dbContext = dbContext;
            _entityToDtoMapping = entityToDtoMapping;
            _dtoToEntityMapping = dtoToEntityMapping;
        }

        public async Task AssignRolesToUser(Guid userId, Guid[] roleIds)
        {
            var user = await _dbContext
                .Users
                .Include(u => u.Roles)
                .SingleOrDefaultAsync(u => u.Id == userId);

            foreach (var roleIdToAssign in roleIds.Except(user.Roles.Select(r => r.Id)))
            {
                var roleToAssign = new Role { Id = roleIdToAssign };
                _dbContext.Attach(roleToAssign);
                user.Roles.Add(roleToAssign);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RoleDto> Create(RoleDto dto)
        {
            var entity = _dtoToEntityMapping.Map(dto);
            _dbContext.Set<Role>().Add(entity);

            await _dbContext.SaveChangesAsync();
            dto = _entityToDtoMapping.Map(entity);
            return dto;

        }

        public async Task<IEnumerable<RoleDto>> Read()
        {
            var entities = await _dbContext
                .Set<Role>()
                .AsNoTracking()
                .Select(_entityToDtoMapping.GetMapping())
                .ToListAsync();
            return entities;
        }
        
        public Task<RoleDto> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        

        

        public Task<RoleDto> Update(RoleDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
