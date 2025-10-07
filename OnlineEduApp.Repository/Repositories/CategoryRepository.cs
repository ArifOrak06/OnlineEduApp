using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;
using System.Linq.Expressions;

namespace OnlineEduApp.Repository.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task<PagedList<Category>> GetAllCategoriesAsync(bool trackChanges,  CategoryParameters categoryParameters, Expression<Func<Category,bool>> predicate= null, params Expression<Func<Category, object>>[] includeProperties)
        {
            List<Category> categories = await GetByFilter(trackChanges, predicate ?? null, includeProperties).ToListAsync();
            if(categories is null)
                throw new ArgumentNullException(nameof(categories));
            return PagedList<Category>.ToPagedList(categories, categoryParameters.PageNumber, categoryParameters.PageSize);
        }
    }
}
