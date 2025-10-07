namespace OnlineEduApp.Core.DTOs.SocialMediaDTOs
{
    public class SocialMediaDtoForCreate
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; } = null!;
        public string Url { get; set; } = null!;

    }
}
