using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.AboutDTOs
{
    public sealed class AboutDtoForUpdate
    {
        [Required(ErrorMessage ="Hakkımızda Id alanı boş geçilemez.")]   
        public int Id { get; set; }

        public bool IsActive { get; set; }

    }
}
