using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRoleRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task InsertUserRoleAsync(UserRoles userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }
    }
}
