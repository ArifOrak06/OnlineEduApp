using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace OnlineEduApp.Core.Repositories
{
    public interface IBannerRepository : IRepositoryBase<Banner>
    {
        Task<PagedList<Banner>> GetAllBannersAsync(bool trackChanges, BannerParameters bannerParameters, Expression<Func<Banner, bool>> predicate = null);
    }
}
