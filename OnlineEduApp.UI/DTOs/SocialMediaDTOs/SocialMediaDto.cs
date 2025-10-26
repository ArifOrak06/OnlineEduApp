namespace OnlineEduApp.UI.DTOs.SocialMediaDTOs
{
    public class SocialMediaDto 
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; } = null!;
        public string Url { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
