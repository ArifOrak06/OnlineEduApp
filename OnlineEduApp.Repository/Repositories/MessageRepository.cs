using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;
using System.Linq.Expressions;

namespace OnlineEduApp.Repository.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Message>> GetAllMessagesAsync(bool trackChanges, MessageParameters messageParameters, Expression<Func<Message, bool>> predicate = null, params Expression<Func<Message, object>>[] includeProperties)
        {
            List<Message>? messages = await GetByFilter(trackChanges, predicate ?? null, includeProperties ?? null).ToListAsync();
            if(messages is null)
                throw new ArgumentNullException(nameof(messages));
            return PagedList<Message>.ToPagedList(messages, messageParameters.PageNumber,messageParameters.PageSize);
        }
    }
}
