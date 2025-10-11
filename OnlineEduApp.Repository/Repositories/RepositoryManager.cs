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
        private readonly Lazy<IContactRepository> _contactRepository;
        private readonly Lazy<IMessageRepository> _messageRepository;

        public RepositoryManager(AppDbContext context)
        {
            _aboutRepository = new Lazy<IAboutRepository>(() => new AboutRepository(context));
            _bannerRepository = new Lazy<IBannerRepository>(() => new BannerRepository(context));
            _blogRepository = new Lazy<IBlogRepository>(() => new BlogRepository(context));
            _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
            _contactRepository = new Lazy<IContactRepository>(() => new ContactRepository(context));
            _messageRepository = new Lazy<IMessageRepository>(() => new MessageRepository(context));
        }

        public IAboutRepository AboutRepository => _aboutRepository.Value;

        public IBannerRepository BannerRepository => _bannerRepository.Value;

        public IBlogRepository BlogRepository => _blogRepository.Value;

        public ICourseRepository CourseRepository => _courseRepository.Value;

        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public IContactRepository ContactRepository => _contactRepository.Value;

        public IMessageRepository MessageRepository => _messageRepository.Value;
    }
}
