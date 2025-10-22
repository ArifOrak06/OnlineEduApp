using Microsoft.Extensions.DependencyInjection;
using OnlineEduApp.Core.Services;
using OnlineEduApp.Service.Services;
using OnlineEduApp.Service.Utilities.AutoMapper;

namespace OnlineEduApp.Service.Extensions.Microsoft
{
    public static class DependencyResolvers
    {
        public static void AddDependenciesForServiceLayer(this IServiceCollection services)
        {
            // Add service layer dependencies here in the future
            services.AddAutoMapper(typeof(AboutProfile));
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IContactService,ContactService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ISocialMediaService,SocialMediaService>();
            services.AddScoped<ISubscriberService, SubscriberService>();
            services.AddScoped<ITestimonialService, TestimonialService>();

        }
    }
}
