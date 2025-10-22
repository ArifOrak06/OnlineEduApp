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
        private readonly Lazy<ISocialMediaRepository> _socialMediaRepository;
        private readonly Lazy<ISubscriberRepository> _subscriberRepository;
        private readonly Lazy<ITestimonialRepository> _testimonialRepository;
        public RepositoryManager(AppDbContext context)
        {
            _aboutRepository = new Lazy<IAboutRepository>(() => new AboutRepository(context));
            _bannerRepository = new Lazy<IBannerRepository>(() => new BannerRepository(context));
            _blogRepository = new Lazy<IBlogRepository>(() => new BlogRepository(context));
            _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
            _contactRepository = new Lazy<IContactRepository>(() => new ContactRepository(context));
            _messageRepository = new Lazy<IMessageRepository>(() => new MessageRepository(context));
            _socialMediaRepository = new Lazy<ISocialMediaRepository>(() => new SocialMediaRepository(context));
            _subscriberRepository = new Lazy<ISubscriberRepository>(() => new  SubscriberRepository(context));
            _testimonialRepository = new Lazy<ITestimonialRepository>(() => new TestimonialRepository(context));
        }

        public IAboutRepository AboutRepository => _aboutRepository.Value;

        public IBannerRepository BannerRepository => _bannerRepository.Value;

        public IBlogRepository BlogRepository => _blogRepository.Value;

        public ICourseRepository CourseRepository => _courseRepository.Value;

        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public IContactRepository ContactRepository => _contactRepository.Value;

        public IMessageRepository MessageRepository => _messageRepository.Value;

        public ISocialMediaRepository SocialMediaRepository => _socialMediaRepository.Value;

        public ISubscriberRepository SubscriberRepository => _subscriberRepository.Value;

        public ITestimonialRepository TestimonialRepository => _testimonialRepository.Value;
    }
}
