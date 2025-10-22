using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace OnlineEduApp.Core.Repositories
{
    public interface ITestimonialRepository : IRepositoryBase<Testimonial>
    {
        Task<PagedList<Testimonial>> GetAllTestimonialsAsync(bool trackChanges, Expression<Func<Testimonial,bool>> predicate,TestimonialParameters testimonialParameters);
    }
}
