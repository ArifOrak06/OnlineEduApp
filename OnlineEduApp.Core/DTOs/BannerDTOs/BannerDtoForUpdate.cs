using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.BannerDTOs
{
    public class BannerDtoForUpdate
    {
        [Required(ErrorMessage ="Id alanı zorunlu bir alandır.")]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
