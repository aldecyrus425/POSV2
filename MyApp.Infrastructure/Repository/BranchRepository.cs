using Microsoft.EntityFrameworkCore;
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
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDBContext _context;
        public BranchRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateBranchAsync(Branches branch)
        {
            await _context.Branches.AddAsync(branch);
            await _context.SaveChangesAsync();
        }

        public async Task<Branches?> GetBranchByIdAsync(int id)
        {
            return await _context.Branches
                .Where(b => b.IsActive)
                .FirstOrDefaultAsync(b => b.BranchId == id);
        }
    }
}
