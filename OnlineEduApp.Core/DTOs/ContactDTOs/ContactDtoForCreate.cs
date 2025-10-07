namespace OnlineEduApp.Core.DTOs.ContactDTOs
{
    public class ContactDtoForCreate
    {
        public string? MapUrl { get; set; }
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
