using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken token = default);
        Task BeginTransactionAsync(CancellationToken token = default);
        Task CommitTransactionAsync(CancellationToken token = default);
        Task RollBackTransactionAsync(CancellationToken token = default);
    }
}
