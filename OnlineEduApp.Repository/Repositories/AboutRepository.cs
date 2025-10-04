using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;
using System.Linq.Expressions;

namespace OnlineEduApp.Repository.Repositories
{
    public class AboutRepository : RepositoryBase<About>, IAboutRepository
    {
        public AboutRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int> CountAboutAsync()
        {
            return await TotalCountAsync();
        }
        public async Task<About> CreateOneAboutAsync(About about)
        {
            return await CreateAsync(about);
        }

        public void DeleteOneAbout(About about)=> Delete(about);

        public async Task<int> FilteredCountAboutAsync(Expression<Func<About, bool>> predicate)
        {
            return await FilteredTotalCountAsync(predicate);
        }

        public async Task<About> GetAboutByIdAsync(bool trackChanges,int id)
        {
            return await GetByFilter(trackChanges, x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task<PagedList<About>> GetAllAboutsAsync(bool trackChanges, AboutParameters aboutParameters, Expression<Func<About, bool>> predicate = null)
        {
            var items = await GetAllAsync(trackChanges, predicate ?? null);
            return PagedList<About>.ToPagedList(items,aboutParameters.PageNumber,aboutParameters.PageSize);
        }

        public IQueryable<About> GetByFilterAbouts(bool trackChanges, Expression<Func<About, bool>> predicate)
        {
            return GetByFilter(trackChanges, predicate);
             
        }

        public About UpdateOneAbout(About about)
        {
            return Update(about);
        }
    }
}
