using System.Linq.Expressions;

namespace OnlineEduApp.Core.Repositories
{
    public interface IRepositoryBase<T> 
    {
        Task<List<T>> GetAllAsync(bool trackChanges, Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetByFilter(bool trackChanges, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task<int> TotalCountAsync();
        Task<int> FilteredTotalCountAsync(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        T Update(T entity);
        Task<T> CreateAsync(T entity);
    }
}
