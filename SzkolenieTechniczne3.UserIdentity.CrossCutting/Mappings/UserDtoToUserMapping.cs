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
    public class UserDtoToUserMapping : Mapping<UserDto, User>
    {
        public override Expression<Func<UserDto, User>> GetMapping()
        {
            return d => new User
            {
                Id = d.Id,
                Email = d.Email!,
                FirstName = d.FirstName,
                LastName = d.FirstName,
                PhoneNumber = d.PhoneNumber
            };
        }
    }
}
