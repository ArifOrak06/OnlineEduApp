namespace OnlineEduApp.Core.DTOs.CategoryDTOs
{
    public class CategoryDtoForUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

    }
}
