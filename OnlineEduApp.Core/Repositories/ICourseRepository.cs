using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace OnlineEduApp.Core.Repositories
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        Task<PagedList<Course>> GetAllCoursesWithCategoryAsync(bool trackChanges, CourseParameters courseParameters, Expression<Func<Course,bool>> predicate = null, params Expression<Func<Course, object>>[] includeProperties);

    }
}
