namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class BlogNotFoundException : NotFoundException
    {
        public BlogNotFoundException(int blogId) : base($"Blog ID : {blogId} olan blog sistemde bulunamamıştır.")
        {
        }
    }
}
