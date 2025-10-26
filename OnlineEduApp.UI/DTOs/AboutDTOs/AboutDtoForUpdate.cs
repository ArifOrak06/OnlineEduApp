using OnlineEduApp.Core.UI.AboutDTOs;
using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.UI.DTOs.AboutDTOs
{
    public sealed class AboutDtoForUpdate : AboutDtoForManipulation
    {
        [Required(ErrorMessage ="Hakkımızda Id alanı boş geçilemez.")]   
        public int Id { get; set; }
        public bool IsActive { get; set; }

    }
}
