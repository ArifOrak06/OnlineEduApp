using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Repository.Contexts.EfCore;

namespace OnlineEduApp.Repository.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IAboutRepository> _aboutRepository;
        private readonly Lazy<IBannerRepository> _bannerRepository;
        private readonly Lazy<IBlogRepository> _blogRepository;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;

        public RepositoryManager(AppDbContext context)
        {
            _aboutRepository = new Lazy<IAboutRepository>(() => new AboutRepository(context));
            _bannerRepository = new Lazy<IBannerRepository>(() => new BannerRepository(context));
            _blogRepository = new Lazy<IBlogRepository>(() => new BlogRepository(context));
            _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
        }

        public IAboutRepository AboutRepository => _aboutRepository.Value;

        public IBannerRepository BannerRepository => _bannerRepository.Value;

        public IBlogRepository BlogRepository => _blogRepository.Value;

        public ICourseRepository CourseRepository => _courseRepository.Value;

        public ICategoryRepository CategoryRepository => _categoryRepository.Value;
    }
}
