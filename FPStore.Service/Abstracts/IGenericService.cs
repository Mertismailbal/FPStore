using FPStore.Core.Abstracts;
using System.Linq.Expressions;

namespace FPStore.Service.Abstracts
{
    public interface IGenericService<T> where T : IEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
        Task<bool> ExistsAsync(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
} 