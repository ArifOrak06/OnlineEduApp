using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace OnlineEduApp.Core.Repositories
{
    public interface IAboutRepository : IRepositoryBase<About>
    {
        Task<PagedList<About>> GetAllAboutsAsync(bool trackChanges, AboutParameters aboutParameters,Expression<Func<About, bool>> predicate = null);
        IQueryable<About> GetByFilterAbouts(bool trackChanges, Expression<Func<About, bool>> predicate);
        Task<About> GetAboutByIdAsync(bool trackChanges, int id);
        Task<int> CountAboutAsync();
        Task<int> FilteredCountAboutAsync(Expression<Func<About, bool>> predicate);
        void DeleteOneAbout(About about);
        About UpdateOneAbout(About about);
        Task<About> CreateOneAboutAsync(About about);
    }
}
