namespace OnlineEduApp.Core.DTOs.SubscriberDTOs
{
    public class SubscriberDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
