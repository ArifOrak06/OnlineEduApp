namespace OnlineEduApp.Core.Utilities.Uow
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();  
    }
}
