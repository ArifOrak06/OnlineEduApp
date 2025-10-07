namespace OnlineEduApp.Core.DTOs.CourseDTOs
{
    public sealed class CourseDtoForCreate
    {

        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }

    }
}
