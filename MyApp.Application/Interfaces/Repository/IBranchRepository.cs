using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IBranchRepository
    {
        Task CreateBranchAsync(Branches branch);
        Task<Branches?> GetBranchByIdAsync(int id);
    }
}
