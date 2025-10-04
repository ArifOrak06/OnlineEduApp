using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.Entities.Abstracts;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;
using System.Linq.Expressions;

namespace OnlineEduApp.Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity, new()
    {
        private readonly AppDbContext _context;
        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> TotalCountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Set<T>().Remove(entity);

        }

        public async Task<int> FilteredTotalCountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().CountAsync(predicate);

        }

        public async Task<List<T>> GetAllAsync(bool trackChanges, Expression<Func<T, bool>> predicate = null)
        {
            return trackChanges ? await _context.Set<T>().ToListAsync() : await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public IQueryable<T> GetByFilter(bool trackChanges, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (!trackChanges)
                query = query.AsNoTracking();
             
            
            query = query.Where(predicate);
            if(includeProperties.Any())
                foreach (var property in includeProperties)
                    query.Include(property);
            return query;


        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
