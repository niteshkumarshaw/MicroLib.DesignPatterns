using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MicroLib.DesignPatterns.UnitOfWorkPattern
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private DbContext _ctx;

        public UnitOfWork(DbContext context)
        {
            _ctx = context;
        }

        public virtual bool Compleate()
        {
            _ctx.SaveChanges();
            return true;
        }

        public async virtual Task<bool> CompleateAsync()
        {
            await _ctx.SaveChangesAsync();
            return true;
        }

        public virtual void Dispose()
        {
            _ctx = null;
            GC.Collect();
        }
    }
}