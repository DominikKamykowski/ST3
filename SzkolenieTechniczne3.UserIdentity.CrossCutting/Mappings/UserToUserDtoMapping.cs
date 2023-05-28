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
    public class UserToUserDtoMapping : Mapping<User, UserDto>
    {
        public override Expression<Func<User, UserDto>> GetMapping()
        {
            return e => new UserDto
            {
                Id = e.Id,
                Email = e.Email,
                FirstName = e.FirstName,
                PhoneNumber = e.PhoneNumber,
                LastName = e.LastName
            };
        }
    }
}
