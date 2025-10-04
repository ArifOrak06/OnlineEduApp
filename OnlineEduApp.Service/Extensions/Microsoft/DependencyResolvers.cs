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

        }
    }
}
