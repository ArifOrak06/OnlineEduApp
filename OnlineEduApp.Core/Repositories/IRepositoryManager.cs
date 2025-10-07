namespace OnlineEduApp.Core.Repositories
{
    public interface IRepositoryManager
    {
        IAboutRepository AboutRepository { get; }
        IBannerRepository BannerRepository { get; }
        IBlogRepository BlogRepository { get; }
        ICourseRepository CourseRepository { get; }
        ICategoryRepository CategoryRepository { get; }
    }
}
