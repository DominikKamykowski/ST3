using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.Common.Storage.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlatformDbContext<TContext>(
            this IServiceCollection serviceCollection,
            Action<DbContextOptionsBuilder>? optionsAction = null,
            ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
            ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
            where TContext : PlatformDbContext
        {
            return serviceCollection.AddDbContext<TContext, TContext>(optionsAction, contextLifetime, optionsLifetime);
        }
    }
}
