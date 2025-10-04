using OnlineEduApp.Core.Utilities.Uow;
using OnlineEduApp.Repository.Contexts.EfCore;

namespace OnlineEduApp.Repository.Utilities.Uow
{
    public class UnitOfWork(AppDbContext _context) : IUnitOfWork
    {
      
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
