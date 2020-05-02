using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicroLib.DesignPatterns.RepositoryPattern
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity Get(TKey key);

        Task<TEntity> GetAsync(TKey key);

        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> GetAll(int page, int pageSize = 20);

        Task<IEnumerable<TEntity>> GetAllAsync(int page, int pageSize = 20);

        TEntity Find(Expression<Func<TEntity, bool>> @expression);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> @expression);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> @expression);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> @expression);

        IEnumerable<TEntity> FindByDescending<TOrder>(
            Expression<Func<TEntity, bool>> @expression,
            Expression<Func<TEntity, TOrder>> @expressionOrder);

        Task<IEnumerable<TEntity>> FindByDescendingAsync<TOrder>(
            Expression<Func<TEntity, bool>> @expression,
            Expression<Func<TEntity, TOrder>> @expressionOrder);

        IEnumerable<TEntity> FindByDescending(
            Expression<Func<TEntity, bool>> @expression,
            Expression<Func<TEntity, object>> @expressionOrder);

        Task<IEnumerable<TEntity>> FindByDescendingAsync(
            Expression<Func<TEntity, bool>> @expression,
            Expression<Func<TEntity, object>> @expressionOrder);

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entitys);
    }
}