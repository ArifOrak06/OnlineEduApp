namespace OnlineEduApp.UI.DTOs.TestimonialDTOs
{
    public class TestimonialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public int Star { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
