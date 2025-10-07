namespace OnlineEduApp.Core.DTOs.ContactDTOs
{
    public class ContactDtoForUpdate
    {
        public int Id { get; set; }
        public string? MapUrl { get; set; }
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
