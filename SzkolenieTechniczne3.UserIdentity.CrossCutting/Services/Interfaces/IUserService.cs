using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.dtos;

namespace SzkolenieTechniczne3.UserIdentity.CrossCutting.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> Read();
        Task<UserDto> ReadById(Guid id);
        Task<CreateNewUserDto> Create(CreateNewUserDto dto);
        Task<UpdateUserDto> Update(UpdateUserDto dto);
        Task Delete(Guid id);
        Task AssignRolesToUser(Guid userId, Guid[] roleIds);
        Task DeleteByPhoneOrEmail(string email, string phoneNumber);
        Task<string> AssingAdminRole(Guid userId);
    }
}
