namespace OnlineEduApp.Core.DTOs.BannerDTOs
{
    public class BannerDtoForUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
