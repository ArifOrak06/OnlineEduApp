namespace OnlineEduApp.Core.Entities.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string errorMessage) :base(errorMessage) { }
    }

    public sealed class BannerNotFoundException : NotFoundException
    {
        public BannerNotFoundException(int bannerId) : base($"Banner with ID: {bannerId} not found")
        {
        }
    }
}
