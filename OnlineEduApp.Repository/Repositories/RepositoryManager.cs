using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;

namespace OnlineEduApp.Repository.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IAboutRepository> _aboutRepository;
        private readonly Lazy<IBannerRepository> _bannerRepository;

        public RepositoryManager(AppDbContext context)
        {
            _aboutRepository = new Lazy<IAboutRepository>(() => new AboutRepository(context));
            _bannerRepository = new Lazy<IBannerRepository>(() => new BannerRepository(context));
        }

        public IAboutRepository AboutRepository => _aboutRepository.Value;

        public IBannerRepository BannerRepository => _bannerRepository.Value;
    }
}
