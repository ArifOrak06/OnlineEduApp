using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;
using System.Linq.Expressions;

namespace OnlineEduApp.Repository.Repositories
{
    public class BannerRepository : RepositoryBase<Banner>, IBannerRepository
    {
        public BannerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Banner>> GetAllBannersAsync(bool trackChanges, BannerParameters bannerParameters, Expression<Func<Banner, bool>> predicate = null)
        {
            var items = await GetAllAsync(trackChanges, predicate ?? null);
            if(items == null)
                throw new ArgumentNullException(nameof(items));
            return PagedList<Banner>.ToPagedList(items, bannerParameters.PageNumber, bannerParameters.PageSize);

        }
    }
}
