using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace OnlineEduApp.Core.Repositories
{
    public interface ISocialMediaRepository : IRepositoryBase<SocialMedia>  
    {
        Task<PagedList<SocialMedia>> GetAllSocialMediasAsync(bool trackChanges, SocialMediaParameters socialMediaParameters,Expression<Func<SocialMedia, bool>> predicate);
    }
}
