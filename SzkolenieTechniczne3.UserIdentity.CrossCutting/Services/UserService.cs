using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.Common.CrossCutting.Exceptions;
using SzkolenieTechniczne3.Common.Storage.Interfaces;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.dtos;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.Mappings;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.Services.Interfaces;
using SzkolenieTechniczne3.UserIdentity.Storage;
using SzkolenieTechniczne3.UserIdentity.Storage.Entities;

namespace SzkolenieTechniczne3.UserIdentity.CrossCutting.Services
{
    public class UserService : IUserService
    {
        private readonly UserIdentityDbContext _dbContext;
        private readonly UserToUserDtoMapping _entityToDtoMapping;
        private readonly UserDtoToUserMapping _dtoToEntityMapping;
        private readonly UpdateUserDtoToUserMapping _dtoUpdateToEntityMapping;

        public UserService(UserIdentityDbContext dbContext, UserToUserDtoMapping entityToDtoMapping,
            UserDtoToUserMapping dtoToEntityMapping, UpdateUserDtoToUserMapping dtoUpdateToEntityMapping)
        {
            _dbContext = dbContext;
            _entityToDtoMapping = entityToDtoMapping;
            _dtoToEntityMapping = dtoToEntityMapping;
            _dtoUpdateToEntityMapping = dtoUpdateToEntityMapping;
        }

        public Task AssignRolesToUser(Guid userId, Guid[] roleIds)
        {
            throw new NotImplementedException();
        }

        public Task<string> AssingAdminRole(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateNewUserDto> Create(CreateNewUserDto dto)
        {
            var entity = _dtoUpdateToEntityMapping.Map(dto);
            _dbContext.Set<User>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return dto;
        }

        public async Task Delete(Guid id)
        {
            var entity = await _dbContext
                .Set<User>()
                .SingleOrDefaultAsync(e => e.Id!.Equals(id));

            if (entity == null)
            {
                throw new ApiHttpException(StatusCodes.Status404NotFound);
            }

            if (entity is ISoftDeletable softDeletableEntity)
            {
                softDeletableEntity.IsDeleted = true;
                _dbContext.Entry(softDeletableEntity).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Set<User>().Remove(entity);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByPhoneOrEmail(string email, string phoneNumber)
        {
            var entity = await _dbContext
                .Set<User>()
                .SingleOrDefaultAsync(e => e.Email!.Equals(email) || e.PhoneNumber!.Equals(phoneNumber));

            if (entity == null)
            {
                throw new ApiHttpException(StatusCodes.Status404NotFound);
            }

            if (entity is ISoftDeletable softDeletableEntity)
            {
                softDeletableEntity.IsDeleted = true;
                _dbContext.Entry(softDeletableEntity).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Set<User>().Remove(entity);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> Read()
        {
            var entities = await _dbContext
            .Set<User>()
            .AsNoTracking()
            .Select(_entityToDtoMapping.GetMapping())
            .ToListAsync();

            return entities;
        }

        public async Task<UserDto> ReadById(Guid id)
        {
            var entity = await _dbContext
                               .Set<User>()
                               .AsNoTracking()
                               .Where(e => e.Id!.Equals(id))
                               .Select(_entityToDtoMapping.GetMapping())
                               .SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new ApiHttpException(StatusCodes.Status404NotFound);
            }

            return entity;
        }

        public async Task<UpdateUserDto> Update(UpdateUserDto dto)
        {
            var dtoId = _dtoUpdateToEntityMapping.Map(dto).Id;

            if (!await _dbContext.Set<User>().AnyAsync(e => e.Id!.Equals(dtoId)))
            {
                throw new ApiHttpException(StatusCodes.Status404NotFound);
            }

            var entity = _dtoUpdateToEntityMapping.Map(dto);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return dto;
        }
    }
}
