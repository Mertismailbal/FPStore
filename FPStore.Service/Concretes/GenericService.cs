using FPStore.Core.Abstracts;
using FPStore.Repository.Abstracts;
using FPStore.Service.Abstracts;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPStore.Service.Concretes
{
    public class GenericService<T> : IGenericService<T> where T : class, IEntity
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<IEnumerable<T>> FindAsync(Expression<System.Func<T, bool>> predicate) => await _repository.FindAsync(predicate);
        public async Task<T> AddAsync(T entity) => await _repository.AddAsync(entity);
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities) => await _repository.AddRangeAsync(entities);
        public async Task<T> UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
        public async Task RemoveAsync(T entity) => await _repository.RemoveAsync(entity);
        public async Task RemoveRangeAsync(IEnumerable<T> entities) => await _repository.RemoveRangeAsync(entities);

        public async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.GetByIdAsync(id) != null;
        }
    }
} 