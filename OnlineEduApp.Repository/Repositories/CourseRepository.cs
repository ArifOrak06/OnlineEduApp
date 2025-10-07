using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;
using System.Linq.Expressions;

namespace OnlineEduApp.Repository.Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task<PagedList<Course>> GetAllCoursesWithCategoryAsync(bool trackChanges, CourseParameters courseParameters, Expression<Func<Course, bool>> predicate = null, params Expression<Func<Course, object>>[] includeProperties)
        {
            List<Course> courses = await GetByFilter(trackChanges, predicate ?? null, includeProperties).ToListAsync();
            if(courses is null)
                throw new ArgumentNullException(nameof(courses));
            return PagedList<Course>.ToPagedList(courses, courseParameters.PageNumber, courseParameters.PageSize);
        }
    }
}
