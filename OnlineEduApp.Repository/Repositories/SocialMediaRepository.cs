using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;
using System.Linq.Expressions;

namespace OnlineEduApp.Repository.Repositories
{
    public class SocialMediaRepository : RepositoryBase<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<SocialMedia>> GetAllSocialMediasAsync(bool trackChanges, SocialMediaParameters socialMediaParameters, Expression<Func<SocialMedia, bool>> predicate)
        {
            List<SocialMedia> socialMedias = await GetByFilter(trackChanges, predicate).ToListAsync();
            if(socialMedias is null)
                throw new ArgumentNullException(nameof(socialMedias));
            return PagedList<SocialMedia>.ToPagedList(socialMedias, socialMediaParameters.PageNumber, socialMediaParameters.PageSize);
        }
    }
}
