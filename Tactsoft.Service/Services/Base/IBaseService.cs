using Tactsoft.Core.Base;
using System.Linq.Expressions;

namespace Tactsoft.Service.Services.Base
{
    public interface IBaseService<T> where T : BaseEntity, new()
    {
        IQueryable<T> All();
        IQueryable<T> All(params Expression<Func<T, Object>>[] includeProperties);
        T Find(long id);
        T Find(Int64 id, params Expression<Func<T, Object>>[] includeProperties);
        void Insert(T entity);
        void Update(T entity, int id);
        void Delete(T entity);


        //Async Methods
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(params Expression<Func<T, Object>>[] includes);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includes);
        Task<T> FindAsync(long id);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(long id, T entity);
        Task<T> UpdateAsync(T entity);
        Task UpdateRangeAsync(List<T> entity);

        Task<T> DeleteAsync(T entity);
        Task DeleteRangeAsync(List<T> entity);

    }
}
