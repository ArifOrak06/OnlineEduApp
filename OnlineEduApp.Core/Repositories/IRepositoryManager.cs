namespace OnlineEduApp.Core.Repositories
{
    public interface IRepositoryManager
    {
        IAboutRepository AboutRepository { get; }
        IBannerRepository BannerRepository { get; }
    }
}
