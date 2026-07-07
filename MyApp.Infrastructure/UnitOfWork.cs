using Microsoft.EntityFrameworkCore.Storage;
using MyApp.Application.Interfaces.Repository;
using MyApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDBContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync(CancellationToken token = default)
        {
            _transaction = await _context.Database.BeginTransactionAsync(token);
        }

        public async Task CommitTransactionAsync(CancellationToken token = default)
        {
            if (_transaction == null)
                return;

            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();

            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task RollBackTransactionAsync(CancellationToken token = default)
        {
            if (_transaction == null)
                return;

            await _transaction.RollbackAsync(token);
            await _transaction.DisposeAsync();

            _transaction = null;
        }

        public async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            return await _context.SaveChangesAsync(token);
        }
    }
}
