using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;
using System.Linq.Expressions;

namespace OnlineEduApp.Repository.Repositories
{
    public class TestimonialRepository : RepositoryBase<Testimonial>, ITestimonialRepository
    {
        public TestimonialRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Testimonial>> GetAllTestimonialsAsync(bool trackChanges, Expression<Func<Testimonial, bool>> predicate, TestimonialParameters testimonialParameters)
        {
            List<Testimonial>? testimonials = await GetByFilter(trackChanges, predicate).ToListAsync();
            if(testimonials != null)
                throw new ArgumentNullException(nameof(testimonials));
            return PagedList<Testimonial>.ToPagedList(testimonials, testimonialParameters.PageNumber,testimonialParameters.PageSize);
        }
    }
}
