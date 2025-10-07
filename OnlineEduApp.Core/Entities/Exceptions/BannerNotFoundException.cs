namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class BannerNotFoundException : NotFoundException
    {
        public BannerNotFoundException(int bannerId) : base($"Banner with ID: {bannerId} not found")
        {
        }
    }
}
