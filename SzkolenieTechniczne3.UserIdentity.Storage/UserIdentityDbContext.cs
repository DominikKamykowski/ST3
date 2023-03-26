using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.Common.Storage;
using SzkolenieTechniczne3.UserIdentity.Storage.Entities;

namespace SzkolenieTechniczne3.UserIdentity.Storage
{
    public class UserIdentityDbContext : PlatformDbContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<SzkolenieTechniczne3.UserIdentity.Storage.Entities.User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        public UserIdentityDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Identity;Trusted_Connection=True;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Identity"));
        }
    }
}
