namespace OnlineEduApp.Core.DTOs.MessageDTOs
{
    public class MessageDtoForCreate
    {
        public string Name { get; set; }
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
