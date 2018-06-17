using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BooksApi.Domain.Interfaces;

namespace BooksApi.Tests
{
    public class StubRepository<TEntity> : IRepository<TEntity>
        where TEntity: class, new()
    {
        public virtual void Create(TEntity instance)
        {

        }

        public virtual async Task CreateAsync(TEntity instance)
        {
            await Task.Delay(500);
        }

        public virtual void Update(TEntity instance)
        {

        }

        public virtual async Task UpdateAsync(TEntity instance)
        {
            await Task.Delay(500);
        }

        public virtual void Delete(TEntity instance)
        {

        }

        public virtual async Task DeleteAsync(TEntity instance)
        {
            await Task.Delay(500);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return new TEntity();
        }

        public virtual TEntity Get(params object[] keyValues)
        {
            return new TEntity();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await Task.Delay(500);

            return new TEntity();
        }

        public virtual async Task<TEntity> GetAsync(params object[] keyValues)
        {
            await Task.Delay(500);

            return new TEntity();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return new List<TEntity>().AsQueryable();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            await Task.Delay(500);
            return new List<TEntity>();
        }

        public virtual void SaveChanges()
        {

        }

        public virtual async Task SaveChangesAsync()
        {
            await Task.Delay(500);
        }

        public void Dispose()
        {
            
        }
    }
}