﻿using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.Mappings;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.Services;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.Services.Interfaces;

namespace SzkolenieTechniczne3.UserIndentity.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<RoleDtoToRoleMapping>();
            serviceCollection.AddSingleton<RoleToRoleDtoMapping>();
            serviceCollection.AddSingleton<UpdateUserDtoToUserMapping>();
            serviceCollection.AddSingleton<UserDtoToUserMapping>();
            serviceCollection.AddSingleton<UserToUserDtoMapping>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IRoleService, RoleService>();
            return serviceCollection;
        }
    }
}
