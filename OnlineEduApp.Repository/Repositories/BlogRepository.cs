using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;
using System.Linq.Expressions;

namespace OnlineEduApp.Repository.Repositories
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task<PagedList<Blog>> GetAllBlogsAsync(bool trackChanges, BlogParameters blogParameters, Expression<Func<Blog, bool>> predicate = null,params Expression<Func<Blog, object>>[] includeProperties)
        {
            var items = await GetByFilter(trackChanges,predicate??null,includeProperties).ToListAsync();
            if(items == null)
                throw new ArgumentNullException(nameof(items));
            return PagedList<Blog>.ToPagedList(items, blogParameters.PageNumber, blogParameters.PageSize);
        }
    }
}
