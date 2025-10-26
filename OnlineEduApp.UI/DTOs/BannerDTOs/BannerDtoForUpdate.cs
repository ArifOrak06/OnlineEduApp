using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.UI.DTOs.BannerDTOs
{
    public class BannerDtoForUpdate : BannerDtoForManipulation
    {
        [Required(ErrorMessage ="Id alanı zorunlu bir alandır.")]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
