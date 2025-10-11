using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.SocialMediaDTOs
{
    public sealed class SocialMediaDtoForUpdate : SocialMediaDtoForManipulation
    {
        [Required(ErrorMessage ="Id alanı zorunlu bir alandır.")]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
