namespace OnlineEduApp.Core.DTOs.CategoryDTOs
{
    public sealed class CategoryDtoForCreate
    {
        public string Name { get; set; } = null!;
        public string? Icon { get; set; }
        public string? Description { get; set; }
    }
}
