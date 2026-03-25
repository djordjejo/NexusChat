using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository <T> where T : class
    {
        public Task<T> AddAsync(T entity);
        public Task<List<T>> AddRangeAsync(List<T> entities);
        public Task DeleteAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> GetByIdAsync(Guid id);
        public Task<List<T>> GetAllAsync();
    }
}
