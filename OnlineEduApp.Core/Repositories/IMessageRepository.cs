using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace OnlineEduApp.Core.Repositories
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        Task<PagedList<Message>> GetAllMessagesAsync(bool trackChanges, MessageParameters messageParameters, Expression<Func<Message, bool>> predicate = null, params Expression<Func<Message, object>>[] includeProperties);
    }
}
