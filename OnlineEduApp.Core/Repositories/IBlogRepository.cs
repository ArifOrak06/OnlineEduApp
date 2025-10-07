using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace OnlineEduApp.Core.Repositories
{
    public interface IBlogRepository : IRepositoryBase<Blog>
    {
        Task<PagedList<Blog>> GetAllBlogsAsync(bool trackChanges,BlogParameters blogParameters, Expression<Func<Blog,bool>> predicate=null, params Expression<Func<Blog, object>>[] includeProperties);

    }
}
