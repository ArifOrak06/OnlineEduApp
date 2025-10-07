namespace OnlineEduApp.Core.DTOs.TestimonialDTOs
{
    public class TestimonialDtoForUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public int Star { get; set; }
        public bool IsActive { get; set; }
    }
}
