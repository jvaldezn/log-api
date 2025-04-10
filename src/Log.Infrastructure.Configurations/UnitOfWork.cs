using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.Infrastructure.Data.Context;
using Log.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace Log.Infrastructure.Configurations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LogDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(LogDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task BeginTransactionAsync() => _transaction = await _context.Database.BeginTransactionAsync();

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
