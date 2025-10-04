using Microsoft.Extensions.DependencyInjection;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Core.Utilities.Uow;
using OnlineEduApp.Repository.Repositories;
using OnlineEduApp.Repository.Utilities.Uow;

namespace OnlineEduApp.Repository.Extensions.Microsoft
{
    public static class DependencyResolvers
    {
        public static void AddDependenciesForRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
