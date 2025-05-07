using FPStore.Core.Entities;
using System.Linq.Expressions;

namespace FPStore.Service.Abstracts
{
    public interface IGenericService<T> where T : class, IEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
} 