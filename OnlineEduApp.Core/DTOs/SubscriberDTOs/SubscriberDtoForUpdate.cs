namespace OnlineEduApp.Core.DTOs.SubscriberDTOs
{
    public class SubscriberDtoForUpdate
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
