using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace OnlineEduApp.Core.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<PagedList<Category>> GetAllCategoriesAsync(bool trackChanges, CategoryParameters categoryParameters, Expression<Func<Category, bool>> predicate = null, params Expression<Func<Category, object>>[] includeProperties);
    }
}
