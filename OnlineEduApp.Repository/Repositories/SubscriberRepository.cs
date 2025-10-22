using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;
using System.Linq.Expressions;

namespace OnlineEduApp.Repository.Repositories
{
    public class SubscriberRepository : RepositoryBase<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Subscriber>> GetAllSubscribersAsync(bool trackChanges, Expression<Func<Subscriber, bool>> predicate, SubscriberParameters subscriberParameters)
        {
            List<Subscriber> subscribers = await GetByFilter(trackChanges, predicate ?? null).ToListAsync();
            if(subscribers is null)
                throw new ArgumentNullException(nameof(subscribers));
            return PagedList<Subscriber>.ToPagedList(subscribers,subscriberParameters.PageNumber, subscriberParameters.PageSize);
        }
    }
}
