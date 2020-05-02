using System;
using System.Threading.Tasks;

namespace MicroLib.DesignPatterns.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        bool Compleate();

        Task<bool> CompleateAsync();
    }
}