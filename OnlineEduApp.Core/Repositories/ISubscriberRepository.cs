using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace OnlineEduApp.Core.Repositories
{
    public interface ISubscriberRepository : IRepositoryBase<Subscriber>
    {
        Task<PagedList<Subscriber>> GetAllSubscribersAsync(bool trackChanges, Expression<Func<Subscriber, bool>> predicate, SubscriberParameters subscriberParameters);
    }
}
