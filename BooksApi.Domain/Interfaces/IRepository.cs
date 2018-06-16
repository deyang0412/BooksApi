using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BooksApi.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Create(TEntity instance);

        Task CreateAsync(TEntity instance);

        void Update(TEntity instance);

        Task UpdateAsync(TEntity instance);

        void Delete(TEntity instance);

        Task DeleteAsync(TEntity instance);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();

        void SaveChanges();

        Task SaveChangesAsync();
    }
}