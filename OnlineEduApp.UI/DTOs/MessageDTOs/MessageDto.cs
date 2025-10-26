namespace OnlineEduApp.UI.DTOs.MessageDTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
