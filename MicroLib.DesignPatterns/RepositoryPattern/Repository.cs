using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicroLib.DesignPatterns.RepositoryPattern
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private DbContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public IEnumerable<TEntity> FindByDescending<TOrder>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TOrder>> expressionOrder)
        {
            return _dbSet.Where(expression)
                .OrderByDescending(expressionOrder)
                .ToList();
        }

        public IEnumerable<TEntity> FindByDescending(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> expressionOrder)
        {
            return _dbSet.Where(expression)
                .OrderByDescending(expressionOrder)
                .ToList();
        }

        public async Task<IEnumerable<TEntity>> FindByDescendingAsync<TOrder>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TOrder>> expressionOrder)
        {
            return await _dbSet.Where(expression)
                .OrderByDescending(expressionOrder)
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindByDescendingAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> expressionOrder)
        {
            return await _dbSet.Where(expression)
                .OrderByDescending(expressionOrder)
                .ToListAsync();
        }

        public TEntity Get(TKey key)
        {
            return _dbSet.Find(key);
        }

        public async Task<TEntity> GetAsync(TKey key)
        {
            return await _dbSet.FindAsync(key);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IEnumerable<TEntity> GetAll(int page, int pageSize = 20)
        {
            return _dbSet.Skip(pageSize * page).Take(pageSize).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(int page, int pageSize)
        {
            return await _dbSet.Skip(pageSize * page).Take(pageSize).ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entitys)
        {
            _dbSet.RemoveRange(entitys);
        }
    }
}