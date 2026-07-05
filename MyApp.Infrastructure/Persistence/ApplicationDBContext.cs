using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(x => x.UserId);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(x => x.UserRoleId);
            });

            modelBuilder.Entity<Branches>(entity =>
            {
                entity.HasKey(x => x.BranchId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(x => x.RoleId);
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Branches> Branches { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}
