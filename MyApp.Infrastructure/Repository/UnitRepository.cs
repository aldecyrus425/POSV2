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
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDBContext _context;

        public UnitRepository(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task CreateUnitAsync(Units units)
        {
            await _context.Units.AddAsync(units);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Units>> getUnitsByIdAsync(IEnumerable<int> ids)
        {
            return await _context.Units.Where(x => ids.Contains(x.UnitId)).ToListAsync();
        }
    }
}
